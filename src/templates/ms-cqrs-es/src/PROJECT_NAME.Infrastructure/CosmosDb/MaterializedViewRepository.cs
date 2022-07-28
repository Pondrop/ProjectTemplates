﻿using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PROJECT_NAME.Application.Interfaces;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Infrastructure.CosmosDb;

public class MaterializedViewRepository<T> : IMaterializedViewRepository<T> where T : EventEntity, new()
{
    private readonly string _containerName;

    private readonly IEventRepository _eventRepository;
    private readonly ILogger<MaterializedViewRepository<T>> _logger;
    private readonly CosmosConfiguration _config;

    private readonly CosmosClient _cosmosClient;
    private readonly SemaphoreSlim _connectSemaphore = new SemaphoreSlim(1, 1);

    private Database? _database;
    private Container? _container;

    public MaterializedViewRepository(
        IEventRepository eventRepository,
        IOptions<CosmosConfiguration> config,
        ILogger<MaterializedViewRepository<T>> logger)
    {
        _containerName = typeof(T).Name.ToLowerInvariant().Replace("entity", "_entities");

        _eventRepository = eventRepository;
        _logger = logger;
        _config = config.Value;

        _cosmosClient =
            new CosmosClient(
                _config.ConnectionString,
                new CosmosClientOptions()
                {
                    ApplicationName = _config.ApplicationName
                });
    }
    public async Task<bool> IsConnectedAsync()
    {
        if (_container is not null)
            return true;

        await _connectSemaphore.WaitAsync();

        try
        {
            if (_container is null)
            {
                _database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_config.DatabaseName);
            }

            if (_database is not null && _container is null)
            {
                _container = await _database.CreateContainerIfNotExistsAsync(_containerName, "/id");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        finally
        {
            _connectSemaphore.Release();
        }

        return _container is not null;
    }

    public async Task<bool> RebuildAsync()
    {
        if (await IsConnectedAsync())
        {
            var streamType = EventEntity.GetStreamTypeName<T>();
            
            var allStreams = await _eventRepository.LoadStreamsByTypeAsync(streamType);

            foreach (var i in allStreams)
            {
                var entity = new T();
                entity.Apply(i.Value.Events);
                await _container!.UpsertItemAsync(entity);
            }

            return true;
        }

        return false;
    }
    
    public async Task<T?> UpsertAsync(T entity)
    {
        if (await IsConnectedAsync())
        {
            var response = await _container!.UpsertItemAsync(entity);
            return response.Resource;
        }

        return default;
    }

    public async Task<List<T>> GetAllAsync()
    {
        var list = new List<T>();
        if (await IsConnectedAsync())
        {
            const string sql = "SELECT * FROM c";
            var iterator = _container!.GetItemQueryIterator<T>(sql);
            while (iterator.HasMoreResults)
            {
                var page = await iterator.ReadNextAsync();
                list.AddRange(page.Resource);
            }
        }
        return list;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        if (id != Guid.Empty && await IsConnectedAsync())
        {
            var idString = id.ToString();
            var result = await _container!.ReadItemAsync<T>(idString, new PartitionKey(idString));
            return result.Resource;
        }
        
        return default;
    }
}
