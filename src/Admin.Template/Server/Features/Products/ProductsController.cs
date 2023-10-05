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
            .Filter(filter.Name, x => x.Name.Contains(filter.Name))
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
        var model = await this.Context.Products.GetById(id);

        if (model == null)
        {
            throw new ValidationException($"Not exists product with id equal {id}");
        }

        return this.Map<Product, ProductModel>(model);
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> Insert([FromBody] CreateProductModel model,
        [FromServices] IValidator<CreateProductModel> createProductValidator)
    {
        await createProductValidator.ValidateAndThrowAsync(model);
        
        var product = this.Map<CreateProductModel,Product>(model);

        await this.Context.Products.AddAsync(product);
        await this.Context.SaveChangesAsync();

        return this.Map<Product,ProductModel>(product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductModel>> Update([FromBody] UpdateProductModel model,
        [FromServices] IValidator<UpdateProductModel> validator)
    {
        await validator.ValidateAndThrowAsync(model);

        var entity = await this.Context.Products.GetById(model.Id);

        if (entity == null)
        {
            throw new ValidationException($"Not exists product with id equal {model.Id}");
        }

        entity = this.From(entity, model);
        await this.Context.SaveChangesAsync();

        return this.Map<Product,ProductModel>(entity);

    }

    [HttpDelete]
    public async Task<ProductModel> Delete(EntityBase model)
    {
        var entity = await this.Context.Products.GetById(model.Id);

        if (entity == null)
        {
            throw new ValidationException($"Not exists product with id equal {model.Id}");
        }

        this.Context.Products.Remove(entity);
        await this.Context.SaveChangesAsync();

        return this.Map<Product,ProductModel>(entity);
    }
}
