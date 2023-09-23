using Admin.Template.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Template.Server.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    public ApiControllerBase(ApplicationDbContext context)
    {
        Context = context;
    }

    protected ApplicationDbContext Context { get; }
}
