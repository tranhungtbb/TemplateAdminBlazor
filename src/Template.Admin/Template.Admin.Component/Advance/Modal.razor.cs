using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Template.Admin.Component.Constants;

namespace Template.Admin.Component.Advance;

public partial class Modal : ComponentBase, IDisposable
{
    private string Id = Guid.NewGuid().ToString();

	[Parameter, EditorRequired]
	public string Title { get; set; }

    [Parameter]
    public string Position { get; set; } = ModalPosition.Default;

    [Parameter]
    public string Size { get; set; } = Constants.Size.Small;

    [Parameter, EditorRequired]
    public RenderFragment ModalBody { get; set; }

	[Parameter, EditorRequired]
	public RenderFragment ModalFooter { get; set; }

    [Inject]
    private IJSRuntime JSInterop { get; set; }

    public async Task Open()
    {
        await this.JSInterop.InvokeVoidAsync("open", $"#{this.Id}");
    }

    public async Task Close()
    {
        await this.JSInterop.InvokeVoidAsync("close", $"#{this.Id}");
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
