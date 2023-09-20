using Admin.Template.Server.Controllers;
using Admin.Template.Server.Data;
using Admin.Template.Server.Features.Products.Models;
using Admin.Template.Server.Models;
using Admin.Template.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Template.Server.Features.Products;

[ApiController]
public class ProductsController : ApiControllerBase
{
    public ProductsController(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<PagedResultModel<ProductModel>> List([FromQuery] PagedProductResultRequestModel filter)
    {
        await Task.CompletedTask;
        return null;
    }
}
