using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Admin.Template.Client.Shared;
public class AppErrorBoundary : ErrorBoundaryBase
{
    [Inject]
    private ILogger<AppErrorBoundary> Logger { get; set; }

    protected override Task OnErrorAsync(Exception exception)
    {
        return Task.CompletedTask;
    }

    protected void RecoverAndClearErrors()
    {
        this.Recover();
    }

    protected override async void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (this.CurrentException is null)
        {
            builder.AddContent(0, this.ChildContent);
            return;
        }

        this.Logger.LogError(this.CurrentException, this.CurrentException.GetBaseException().Message);

        if (this.ErrorContent is null)
        {
            return;
        }

        var messageError = string.Empty;

        builder.AddContent(1, this.ErrorContent(this.CurrentException));

        this.RecoverAndClearErrors();
    }
}
