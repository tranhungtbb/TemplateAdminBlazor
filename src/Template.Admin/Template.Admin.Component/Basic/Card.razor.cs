using Microsoft.AspNetCore.Components;

namespace Template.Admin.Component.Basic;

public partial class Card : ComponentBase
{
    [Parameter]
    public string CssClass { get; set; } = string.Empty;

    [Parameter]
    public RenderFragment ChildContent { get; set; }
}
