using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using PROJECT_NAME.Application.Interfaces;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Infrastructure.CosmosDb;
using System;
using Xunit;

namespace PROJECT_NAME.Infrastructure.Tests;

public class EventRepositoryTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<ILogger<EventRepository>> _loggerMock;
        
    public EventRepositoryTests()
    {
        _mapperMock = new Mock<IMapper>();
        _loggerMock = new Mock<ILogger<EventRepository>>();
    }
    
    [Fact]
    public void InvalidCosmosDbConfig_ShouldThrowArgumentException()
    {
        // arrange
        var config = new CosmosConfiguration();
        
        // act
        var createNewEvtRepo = () =>
            new EventRepository(
                _mapperMock.Object,
                new OptionsWrapper<CosmosConfiguration>(config),
                _loggerMock.Object);
        
        // assert
        Assert.Throws<ArgumentException>(() => createNewEvtRepo.Invoke());
    }
    
    [Fact]
    public void ValidCosmosDbConfig_ShouldCreateEventRepository()
    {
        // arrange
        var config = new CosmosConfiguration()
        {
            ApplicationName = "My Awesome App",
            DatabaseName = "db1",
            ConnectionString = "AccountEndpoint=https://exampledb.documents.azure.com:443/;AccountKey=dGhlIG1vc3Qgc2VjcmV0IGtleSBldmVyIGRldmlzZWQh;"
        };
        
        // act
        var createNewEvtRepo = () =>
            new EventRepository(
                _mapperMock.Object,
                new OptionsWrapper<CosmosConfiguration>(config),
                _loggerMock.Object);
        
        // assert
        Assert.IsType<EventRepository>(createNewEvtRepo.Invoke());
    }
}