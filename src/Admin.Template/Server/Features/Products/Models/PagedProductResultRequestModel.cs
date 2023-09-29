namespace Admin.Template.Server.Features.Products.Models;

public class PagedProductResultRequestModel : PagedResultRequestModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string? Brand { get; set; }
    public decimal? Price { get; set; }
    public DateTime? Created { get; set; }
}
