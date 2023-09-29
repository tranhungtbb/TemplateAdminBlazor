using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Admin.Template.Component.Advance;

public partial class DataTable<TItem> : ComponentBase
{
    private int pageIndex { get; set; } = 1;

    private string? search { get; set; }

    private int numberOfPages => (int)Math.Ceiling((double)(this.Count / (this.PageSize > 0 ? this.PageSize : 1D)));

    private IEnumerable<TItem> data;

    [Parameter]
    public EventCallback<LoadDataEventArgs> LoadData { get; set; }

    [Parameter]
    public EventCallback OnClickFilter { get; set; }

    [Parameter]
    public int? Count { get; set; }

    [Parameter]
    public int PageSize { get; set; }

    [Parameter]
    public IEnumerable<TItem> Data
    {
        get => data;
        set
        {
            if (data != value)
            {
                data = value;
                this.StateHasChanged();
            }
        }
    }

    [Parameter]
    public RenderFragment? DataTableHeader { get; set; }

    [Parameter, EditorRequired]
    public RenderFragment<TItem> DataTableItems { get; set; }

    [Parameter]
    public bool IsLoading { get; set; } = true;

    [Parameter]
    public bool AllowSorting { get; set; }

    [Parameter]
    public bool AllowFiltering { get; set; }

    [Parameter]
    public bool AllowSearch { get; set; } = true;

    [Parameter]
    public bool AllowVirtualization { get; set; }

    [Parameter]
    public bool FixedHeader { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
    }

    async Task OnDataChanged()
    {
        await LoadData.InvokeAsync(new LoadDataEventArgs()
        {
            PageSize = PageSize,
            PageIndex = pageIndex,
            OrderBy = string.Empty,
            Search = AllowSearch ? search : string.Empty,
        });

        IsLoading = false;
        StateHasChanged();
    }

    private async Task ChangePage(int index)
    {
        this.pageIndex = index;
        await this.OnDataChanged();
    }

    private async Task OnSeachChange(KeyboardEventArgs args)
    {
        if (args.Code == "Enter" || args.Code == "NumpadEnter")
        {
            await this.OnDataChanged();
        }
    }
}
