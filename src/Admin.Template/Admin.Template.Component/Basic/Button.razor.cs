﻿using Microsoft.AspNetCore.Components;
using Admin.Template.Component.Constants;

namespace Admin.Template.Component.Basic;

public partial class Button : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();

    [Parameter]
    public string Appearance { get; set; } = Constants.Appearance.Primary;

	[Parameter]
	public string @Type { get; set; } = ButtonType.Default;

	[Parameter]
    public string Size { get; set; } = Constants.Size.Small;

    [Parameter]
    public bool IsDisable { get; set; } = false;

    [Parameter]
    public string CssClass { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public bool Shadown { get; set; } = true;
}
