namespace Admin.Template.Client.Pages.Products.Models;

public class FilterProductModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string? Brand { get; set; }
    public decimal? Price { get; set; }

    public DateTimeOffset? Created { get; set; }

    public string? Search { get; set; }

    public string? OrderBy { get; set; }
}
