using Admin.Template.Server.Controllers;
using Admin.Template.Server.Data;
using Admin.Template.Server.Data.Entity;
using Admin.Template.Server.Features.Products.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Admin.Template.Server.Features.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ApiControllerBase
{
    public ProductsController(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
    {
    }

    [HttpGet]
    public async Task<PagedResultModel<ProductModel>> List([FromQuery] PagedProductResultRequestModel filter)
    {
        var query = this.Context.Products
            .Filter(filter.Search, 
                x => x.Name.Contains(filter.Search)
                || x.Description.Contains(filter.Search)
                || x.Unit.Contains(filter.Search)
                || x.Brand.Contains(filter.Search))
            .Filter(filter.Name, x=>x.Name.Contains(filter.Name))
            .Filter(filter.Description, x => x.Description.Contains(filter.Description))
            .Filter(filter.Unit, x => x.Unit.Contains(filter.Unit))
            .Filter(filter.Brand, x => x.Brand.Contains(filter.Brand))
            .Filter(filter.Price, x => x.Price == filter.Price)
            .OrderBy(filter.OrderBy);

        var result = await this.Map<Product, ProductModel>(query.ToPageList(filter))
            .ToPageResult(await query.CountAsync(), filter);

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
            Price = 1200,
            Created = DateTime.Now,
            CreateByName = "Admin",
            ModifyByName = "Admin",
        };
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> Insert([FromBody] CreateProductModel model,
        [FromServices] IValidator<CreateProductModel> createProductValidator)
    {
        await createProductValidator.ValidateAndThrowAsync(model);

        return new ProductModel()
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
        };
    }

    [HttpPut]
    public async Task<ActionResult<ProductModel>> Update([FromBody] UpdateProductModel model,
        [FromServices] IValidator<UpdateProductModel> validator)
    {
        await validator.ValidateAndThrowAsync(model);

        return new ProductModel()
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
            Price = 1200,
            Created = DateTime.Now,
            CreateByName = "Admin",
            ModifyByName = "Admin",
        };
    }
}
