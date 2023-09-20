using Admin.Template.Shared.Models.Entity;

namespace Admin.Template.Server.Data.Entity;

public class Product : EntityBase
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Unit { get; set; }

    public string? Brand { get; set; }

    public decimal Price { get; set; }

    public List<ProductImage>? Pictures { get; set; }
}
