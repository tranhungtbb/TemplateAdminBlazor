using Admin.Template.Server.Controllers;
using Admin.Template.Server.Data;
using Admin.Template.Server.Features.Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Template.Server.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ApiControllerBase
{
    private readonly ApplicationDbContext context;

    public ProductsController(ApplicationDbContext context)
        : base(context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<PagedResultModel<ProductModel>> List([FromQuery] PagedProductResultRequestModel filter)
    {
        var products = new List<ProductModel>
        {
            new ProductModel()
            {
                Name = "Tech Toys",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200
            },
            new ProductModel()
            {
                Name = "Crazy Creations",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
            },
            new ProductModel()
            {
                Name = "Innovative Imaginings",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
            },
            new ProductModel()
            {
                Name = "Design Den",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
            },
            new ProductModel()
            {
                Name = "Idea Outfitters",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
            },
            new ProductModel()
            {
                Name = "The Inventors Nest",
                Description = "text lorem ipsum dolor sit amet",
                Unit = "Nomal",
                Brand = "Adidas",
                Price = 1200,
            },
        };

        var result = await products
            .AsQueryable()
            .ToPageResult(filter);

        return result;
    }

    [HttpGet("Get/{id:long}")]
    public async Task<ProductModel> Get(long id)
    {
        return new ProductModel()
        {
            Id = 1,
            Name = "Tech Toys",
            Description = "text lorem ipsum dolor sit amet",
            Unit = "Nomal",
            Brand = "Adidas",
            Price = 1200
        };
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> Insert([FromBody] CreateProductModel model,
        [FromServices] IValidator<CreateProductModel> createProductValidator)
    {
        var result = await createProductValidator.ValidateAsync(model);

        if (!result.IsValid)
        {
            return this.Failed(result);
        }

        return new ProductModel()
        {
            Id = 1,
            Name = "Tech Toys",
            Description = "text lorem ipsum dolor sit amet",
            Unit = "Nomal",
            Brand = "Adidas",
            Price = 1200
        };
    }

    [HttpPut]
    public async Task<ActionResult<ProductModel>> Update([FromBody] UpdateProductModel model,
        [FromServices] IValidator<UpdateProductModel> validator)
    {
        var result = await validator.ValidateAsync(model);

        if (!result.IsValid)
        {
            return this.Failed(result);
        }

        return new ProductModel()
        {
            Id = 1,
            Name = "Tech Toys",
            Description = "text lorem ipsum dolor sit amet",
            Unit = "Nomal",
            Brand = "Adidas",
            Price = 1200
        };
    }

    [HttpDelete]
    public async Task<ActionResult<ProductModel>> Delete(EntityBase model)
    {
        return new ProductModel()
        {
            Id = 1,
            Name = "Tech Toys",
            Description = "text lorem ipsum dolor sit amet",
            Unit = "Nomal",
            Brand = "Adidas",
            Price = 1200
        };
    }
}
