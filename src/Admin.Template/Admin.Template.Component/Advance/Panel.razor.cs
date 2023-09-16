using Microsoft.AspNetCore.Components;

namespace Template.Admin.Component.Advance;

public partial class Panel
{
	private bool IsOpen { get; set; } = false;

	[Parameter, EditorRequired]
	public string Title { get; set; }

	[Parameter, EditorRequired]
	public RenderFragment PanelBody { get; set; }

	[Parameter]
	public RenderFragment PanelFooter { get; set; }

	public void Open()
	{
		this.IsOpen = true;
	}

	public void Close()
	{
		this.IsOpen = false;
	}
}
