namespace Admin.Template.Server.Features.Products.Models;

public class UpdateProductModel : EntityBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string? Brand { get; set; }
    public decimal Price { get; set; }
}

