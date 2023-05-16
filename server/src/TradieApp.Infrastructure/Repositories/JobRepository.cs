using TradieApp.Domain.Entities;
using TradieApp.Domain.Repositories;
using TradieApp.Infrastructure.Data;

namespace TradieApp.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly AppDbContext _dbContext;

    public JobRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Job> GetByIdAsync(int jobId)
    {
        return await _dbContext.Jobs.FindAsync(jobId);
    }

    public async Task UpdateAsync(Job job)
    {
        _dbContext.Jobs.Update(job);
        await _dbContext.SaveChangesAsync();
    }

    // Implement other methods for CRUD operations and querying
}
