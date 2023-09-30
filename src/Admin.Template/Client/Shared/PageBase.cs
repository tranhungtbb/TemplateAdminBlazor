
using Microsoft.JSInterop;

namespace Admin.Template.Client.Shared;

public abstract class PageBase : ComponentBase, IDisposable
{
    [Inject]
    protected NavigationManager Navigation { get; set; }

    [Inject]
    protected IJSRuntime JS { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
