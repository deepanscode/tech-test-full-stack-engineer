using System;
using System.Linq.Expressions;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradieApp.Application.Repository;
using TradieApp.Domain.Common;
using TradieApp.Infrastructure.Data;

namespace TradieApp.Infrastructure.Repositories;

public class GenericRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : Entity
{
    protected readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext context): base(context)
    {
        _dbContext = context;
    }

}
