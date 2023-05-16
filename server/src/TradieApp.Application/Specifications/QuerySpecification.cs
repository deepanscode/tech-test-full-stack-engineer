using System;
using System.Linq.Expressions;
using Ardalis.Specification;

namespace TradieApp.Application.Specifications;

public enum OrderBy { None, ASC, DESC }

public class QuerySpecification<TEntity> : Specification<TEntity> where TEntity : class
{
    /// <summary>
    /// Adds a Where clause for the query.
    /// </summary>
    /// <param name="whereExpresson"></param>
    public void AddWhere(Expression<Func<TEntity, bool>> whereExpresson)
    {
        Query.Where(whereExpresson);
    }

    /// <summary>
    /// Adds search clause for the query
    /// Use this after all the where to improve performance
    /// </summary>
    /// <param name="selector"></param>
    /// <param name="searchTerm"></param>
    /// <param name="searchGroup">1 - OR, 2 - AND</param>
    public void AddSearch(Expression<Func<TEntity, string>> selector, string searchTerm, int searchGroup = 1)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return;
        }

        Query.Search(selector, $"%{searchTerm}%", searchGroup);
    }

    /// <summary>
    /// Add no tracking
    /// </summary>
    /// <param name="whereExpresson"></param>
    public void AddNotracking()
    {
        Query.AsNoTracking();
    }

    /// <summary>
    /// Include related entity
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="includeExpression"></param>
    public IIncludableSpecificationBuilder<TEntity, TProperty> AddInclude<TProperty>(Expression<Func<TEntity, TProperty>> includeExpression)
    {
        return Query.Include(includeExpression);
    }

    /// <summary>
    /// Set paging for the Query
    /// </summary>
    /// <param name="skip">Number of items to be skipped</param>
    /// <param name="take">Number of items to retrive</param>
    public void SetPaging(int skip, int take)
    {
        Query.Skip(skip).Take(take);
    }

    public void AddOrderBy(string[] sortParams, OrderBy orderBy = OrderBy.ASC)
    {
        IOrderedSpecificationBuilder<TEntity> query = null!;
        foreach (var sort in sortParams)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var body = sort.Split('.').Aggregate((Expression)parameter, Expression.Property);
                if (body.Type.IsValueType) body = Expression.Convert(body, typeof(object));
                var selector = Expression.Lambda<Func<TEntity, object>>(body, parameter);
                if (query == null)
                {
                    query = AddOrderBy(selector, orderBy);
                }
                else
                {
                    AddThenBy(query, selector, orderBy);
                }
            }
        }
    }

    /// <summary>
    /// Set Ordering for the query
    /// </summary>
    /// <param name="orderExpression"></param>
    /// <param name="orderBy"></param>
    public IOrderedSpecificationBuilder<TEntity> AddOrderBy(Expression<Func<TEntity, object>> orderExpression, OrderBy orderBy = OrderBy.ASC)
    {
        switch (orderBy)
        {
            case OrderBy.ASC:
                return Query.OrderBy(orderExpression!);

            case OrderBy.DESC:
                return Query.OrderByDescending(orderExpression!);

            default:
                throw new ArgumentOutOfRangeException(nameof(orderBy));
        }
    }

    public IOrderedSpecificationBuilder<TEntity> AddThenBy(IOrderedSpecificationBuilder<TEntity> query, Expression<Func<TEntity, object>> orderExpression, OrderBy orderBy = OrderBy.ASC)
    {
        switch (orderBy)
        {
            case OrderBy.ASC:
                return query.ThenBy(orderExpression!);

            case OrderBy.DESC:
                return query.ThenByDescending(orderExpression!);

            default:
                throw new ArgumentOutOfRangeException(nameof(orderBy));
        }
    }
}

public static class QuerySpecificationExtensions
{
    /// <summary>
    /// Include child entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TPreviousProperty"></typeparam>
    /// <param name="previousBuilder"></param>
    /// <param name="thenIncludeExpression"></param>
    /// <returns></returns>
    public static IIncludableSpecificationBuilder<TEntity, TProperty> AddThenInclude<TEntity, TProperty, TPreviousProperty>(
        this IIncludableSpecificationBuilder<TEntity, TPreviousProperty> previousBuilder,
        Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression
        ) where TEntity : class
    {
        return previousBuilder.ThenInclude(thenIncludeExpression);
    }

    /// <summary>
    /// Include child entity
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TPreviousProperty"></typeparam>
    /// <param name="previousBuilder"></param>
    /// <param name="thenIncludeExpression"></param>
    /// <returns></returns>
    public static IIncludableSpecificationBuilder<TEntity, TProperty> AddThenInclude<TEntity, TProperty, TPreviousProperty>(
       this IIncludableSpecificationBuilder<TEntity, IEnumerable<TPreviousProperty>> previousBuilder,
       Expression<Func<TPreviousProperty, TProperty>> thenIncludeExpression
       ) where TEntity : class
    {
        return previousBuilder.ThenInclude(thenIncludeExpression);
    }
}

