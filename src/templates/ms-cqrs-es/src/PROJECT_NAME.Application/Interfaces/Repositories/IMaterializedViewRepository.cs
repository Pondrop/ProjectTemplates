using PROJECT_NAME.Application.Commands;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Interfaces;

public interface IMaterializedViewRepository<T> where T : EventEntity
{
    Task<bool> IsConnectedAsync();
    
    Task<bool> RebuildAsync();
    Task<T?> UpsertAsync(T item);
    
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
}