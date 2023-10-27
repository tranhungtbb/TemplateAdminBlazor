namespace Admin.Template.Shared.Models;

public class PagedResultRequestModel
{
    public int? PageSize { get; set; }

    public int? PageIndex { get; set; }

    public string? Search { get; set; }

    public string? OrderBy { get; set; } = string.Empty;

    public bool OrderByDesc { get; set; }

    public string? ThenBy { get; set; } = string.Empty;

    public bool ThenByDesc { get; set; }
}
