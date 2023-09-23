using Microsoft.AspNetCore.Components.Routing;

namespace Admin.Template.Client.Shared;

public abstract class PageBase : ComponentBase
{
    [Inject]
    protected INavigationInterception Navigation { get; }
}
