using Admin.Template.Server.Data.Entity;

namespace Admin.Template.Server.Features.Products.Models;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductModel, Product>();

        CreateMap<Product, ProductModel>();

        CreateMap<CreateProductModel, Product>();

        CreateMap<UpdateProductModel, Product>();
    }
}
