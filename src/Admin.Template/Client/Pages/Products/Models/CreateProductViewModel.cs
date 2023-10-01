namespace Admin.Template.Client.Pages.Products.Models;

public class CreateProductViewModel : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string? Brand { get; set; }
    public decimal? Price { get; set; }
}

