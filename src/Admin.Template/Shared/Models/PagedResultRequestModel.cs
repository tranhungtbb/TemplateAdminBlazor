namespace Admin.Template.Shared.Models;

public class PagedResultRequestModel
{
    public int? PageSize { get; set; }

    public int? PageIndex { get; set; }

    public string? Search { get; set; }

    public string? OrderBy { get; set; } = string.Empty;
}
