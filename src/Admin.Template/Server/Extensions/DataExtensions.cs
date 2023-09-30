using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Admin.Template.Server.Extensions;

public static class DataExtensions
{
    public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string? orderBy)
    {
        if (!string.IsNullOrEmpty(orderBy))
        {
            query = query.OrderBy(s => s.GetType().GetProperty(orderBy).GetValue(s, null));
        }

        return query;
    }


    public static IQueryable<T> ToPageList<T>(this IQueryable<T> query, PagedResultRequestModel filter)
        where T : EntityBase
    {
        query = query.Skip(filter.PageSize ?? 10 * filter.PageIndex ?? 0)
            .Take(filter.PageSize ?? 10);
        return query;
    }

    public static async Task<PagedResultModel<T>> ToPageResult<T>(this IQueryable<T> query, int count, PagedResultRequestModel filter)
        where T : EntityBase
    {
        return new PagedResultModel<T>
        {
            Items = await query.ToListAsync(),
            TotalCount = count,
            PageIndex = filter.PageIndex ?? 1,
            PageSize = filter.PageSize ?? 10,
        };
    }

    public static IQueryable<T> Filter<T>(this IQueryable<T> query, string? filter, Expression<Func<T, bool>> predicate)
        where T : EntityBase
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            return query;
        }
        return query.Where(predicate);
    }

    public static IQueryable<T> Filter<T>(this IQueryable<T> query, int? filter, Expression<Func<T, bool>> predicate)
        where T : EntityBase
    {
        if (filter == null)
        {
            return query;
        }
        return query.Where(predicate);
    }

    public static IQueryable<T> Filter<T>(this IQueryable<T> query, decimal? filter, Expression<Func<T, bool>> predicate)
        where T : EntityBase
    {
        if (filter == null)
        {
            return query;
        }
        return query.Where(predicate);
    }
}
