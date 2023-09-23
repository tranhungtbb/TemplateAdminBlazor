using Microsoft.EntityFrameworkCore;

namespace Admin.Template.Server.Extensions;

public static class DataExtensions
{
    public static IQueryable<T> ToPageList<T>(this IQueryable<T> query, PagedResultRequestModel filter)
        where T : EntityBase
    {
        if (!string.IsNullOrEmpty(filter.OrderBy))
        {
            query = query.OrderBy(s => s.GetType().GetProperty(filter.OrderBy).GetValue(s, null));
        }
        
        query = query.Skip(filter.PageSize ?? 10 * filter.PageIndex ?? 0)
            .Take(filter.PageSize ?? 10);
        return query;
    }

    public static async Task<PagedResultModel<T>> ToPageResult<T>(this IQueryable<T> query, PagedResultRequestModel filter)
        where T : EntityBase
    {
        return new PagedResultModel<T>
        {
            Items = query.ToPageList(filter),
            TotalCount = await query.LongCountAsync(),
            PageIndex = filter.PageIndex,
            PageSize = filter.PageSize,
        };
    }
}
