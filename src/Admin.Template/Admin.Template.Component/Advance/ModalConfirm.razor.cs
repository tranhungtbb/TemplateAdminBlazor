using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Admin.Template.Component.Constants;

namespace Template.Admin.Component.Advance;

public partial class ModalConfirm : ComponentBase, IDisposable
{
	private string Id = Guid.NewGuid().ToString();

	[Parameter, EditorRequired]
	public string Title { get; set; }

	[Parameter]
	public string Position { get; set; } = ModalPosition.Default;

	[Parameter, EditorRequired]
	public RenderFragment ModalBody { get; set; }

	[Parameter]
	public EventCallback OnYes { get; set; }

	[Inject]
	private IJSRuntime JSInterop { get; set; }

	public async Task Open()
	{
		await this.JSInterop.InvokeVoidAsync("open", $"#{this.Id}");
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
	}

	private async Task OnOK()
	{
		if (this.OnYes.HasDelegate)
		{
			_ = this.OnYes.InvokeAsync();
		}
		await this.JSInterop.InvokeVoidAsync("close", $"#{this.Id}");
	}
}
