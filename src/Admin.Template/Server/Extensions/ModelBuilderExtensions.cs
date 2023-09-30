using Admin.Template.Server.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Admin.Template.Server.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedDatas(this ModelBuilder builder)
    {
        builder.Entity<Product>().HasData(
            new Product()
            {
                Id = 1,
                Name = "Tech Toys",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
                Created = DateTime.Now,
                CreateByName = "Admin",
                ModifyByName = "Admin",
            },
            new Product()
            {
                Id = 2,
                Name = "Crazy Creations",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
                Created = DateTime.Now,
                CreateByName = "Admin",
                ModifyByName = "Admin",
            },
            new Product()
            {
                Id = 3,
                Name = "Innovative Imaginings",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
                Created = DateTime.Now,
                CreateByName = "Admin",
                ModifyByName = "Admin",
            },
            new Product()
            {
                Id = 4,
                Name = "Design Den",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
                Created = DateTime.Now,
                CreateByName = "Admin",
                ModifyByName = "Admin",
            });
    }
}
