using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Admin.Template.Component.Enums;

namespace Admin.Template.Component.Services;

public class ToastService
{
	[Inject]
	private IJSRuntime JsRuntime { get; set; }

	public async Task ShowToast(string message, ToastLevel toastLevel)
	{
		await this.JsRuntime.InvokeVoidAsync("notyf.open", new
		{
			Message = message,
			Type = toastLevel.ToString().ToLower(),
			Dismissible = true,
		});
	}
}
