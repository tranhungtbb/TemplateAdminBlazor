using Admin.Template.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Template.Server.Controllers;

[ApiController]
public class ApiControllerBase : ControllerBase
{
    public ApiControllerBase(ApplicationDbContext context)
    {
        Context = context;
    }

    public ApplicationDbContext Context { get; }
}
