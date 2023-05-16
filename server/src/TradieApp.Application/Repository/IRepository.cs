using System;
using System.Linq.Expressions;
using Ardalis.Specification;
using TradieApp.Domain.Common;

namespace TradieApp.Application.Repository;

public interface IRepository<T> : IRepositoryBase<T> where T : Entity
{
}

