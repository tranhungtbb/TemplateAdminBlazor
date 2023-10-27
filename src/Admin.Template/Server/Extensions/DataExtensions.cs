using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Admin.Template.Server.Extensions;

public static class DataExtensions
{
    public static IQueryable<T> ToPageList<T>(this IQueryable<T> query, PagedResultRequestModel filter)
        where T : EntityBase
    {
        int pageIndex = filter.PageIndex ?? 0;
        pageIndex = pageIndex <= 1 ? 0 : pageIndex - 1;

        int  pageSize = filter.PageSize ?? 10;
        query = query.Skip(pageSize * pageIndex)
            .Take(pageSize);
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

    public static async Task<T?> GetById<T>(this IQueryable<T> query, long id)
        where T : EntityBase
    {
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public static IQueryable<T> IsActive<T>(this IQueryable<T> query)
        where T : IHasIsDeleted
    {
        return query.Where(x => !x.IsDeleted);
    }
}
