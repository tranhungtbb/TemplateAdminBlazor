namespace Admin.Template.Component.Advance;

public class LoadDataEventArgs
{
    public int PageSize { get; set; }

    public int PageIndex { get; set; }

    public string? OrderBy { get; set; }

    public string? Search { get; set; }

}