
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
        if(firstRender)
        {
            await JS.InvokeAsync<object>("feather.replace");
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
