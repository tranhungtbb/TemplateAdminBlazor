// <copyright file="ActionLink.razor.cs" company="Geidans Solutions">
// Copyright (c) Geidans Solutions. All rights reserved. Unauthorized copying of this file, via any medium is strictly prohibited. Proprietary and confidential.
// </copyright>

using Microsoft.AspNetCore.Components;

namespace Admin.Template.Component.Basic;

public partial class ActionLink : ComponentBase
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string CssClass { get; set; }

    [Parameter]
    public string Href { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; } = new Dictionary<string, object>();
}
