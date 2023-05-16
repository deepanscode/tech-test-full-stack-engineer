using TradieApp.Domain.Entities;

namespace TradieApp.Domain.Repositories;

public interface IJobRepository
{
    Task<Job> GetByIdAsync(int jobId);
    Task UpdateAsync(Job job);
    // Define other methods for CRUD operations and querying
}

