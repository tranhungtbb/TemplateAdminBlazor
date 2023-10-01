using Microsoft.JSInterop;
using Admin.Template.Component.Enums;

namespace Admin.Template.Component.Services;

public class ToastService
{
	private readonly IJSRuntime JsRuntime;
	public ToastService(IJSRuntime jsRuntime)
	{
		this.JsRuntime = jsRuntime;
	}

	public async Task ShowToast(string message, ToastLevel toastLevel = ToastLevel.Success)
	{
		await this.JsRuntime.InvokeVoidAsync("notyf.open", new
		{
			Message = message,
			Type = toastLevel.ToString().ToLower(),
			Dismissible = true,
		});
	}
}
