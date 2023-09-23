using Admin.Template.Shared.Models.Entity;

namespace Admin.Template.Shared.Models;

public class PagedResultModel<T> where T : EntityBase
{
    public IQueryable<T> Items { get; set; }

    public int? PageSize { get; set; }

    public int? PageIndex { get; set; }

    public long TotalCount { get; set; }
}
