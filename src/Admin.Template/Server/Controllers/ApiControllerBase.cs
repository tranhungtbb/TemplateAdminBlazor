using Admin.Template.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Template.Server.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private readonly IMapper mapper;

    public ApiControllerBase(ApplicationDbContext context, IMapper mapper)
    {
        Context = context;
        this.mapper = mapper;
    }

    protected ApplicationDbContext Context { get; }

    protected IQueryable<TDestination> Map<TSource, TDestination>(IQueryable<TSource> query)
    {
        return mapper.ProjectTo<TDestination>(query);
    }
}
