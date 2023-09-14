using Microsoft.AspNetCore.Components;

namespace Template.Admin.Component.Advance;

public partial class StatisticsCard
{
	[Parameter]
	public string Title { get; set; }

	[Parameter]
	public string Statistics { get; set; }

	[Parameter]
	public string Timeline { get; set; }

	[Parameter]
	public string Percentage { get; set; }

	[Parameter]
	public RenderFragment Icon { get; set; }
}
