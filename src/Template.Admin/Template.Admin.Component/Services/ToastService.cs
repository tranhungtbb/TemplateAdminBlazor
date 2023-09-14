﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Template.Admin.Component.Enums;

namespace Template.Admin.Component.Services;

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
