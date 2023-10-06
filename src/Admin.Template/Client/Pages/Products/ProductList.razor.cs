using Admin.Template.Client.Pages.Products.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Admin.Template.Client.Pages.Products;

public partial class ProductList : PageBase
{
    private ListProductViewModel products;

    private int pageSize = 19, pageIndex = 1;

    private FilterProductModel filterModel = new();

    [Inject]
    private ProductsClient ProductsClient { get; set; }

    private EditContext filterContext { get; set; }

    private Panel panelFilter;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        this.filterContext = new EditContext(filterModel);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await LoadData(new LoadDataEventArgs
            {
                PageIndex = 1,
                PageSize = this.pageSize,
                Search = filterModel.Search,
                OrderBy = filterModel.OrderBy,
            });
        }
    }

    private async Task LoadData(LoadDataEventArgs args)
    {
        pageSize = args.PageSize;
        pageIndex = args.PageIndex;
        filterModel.Search = args.Search;
        filterModel.OrderBy = args.OrderBy;
        var result = await ProductsClient.ListAsync(
            name: filterModel.Name,
            description: filterModel.Description,
            unit: filterModel.Unit,
            brand: filterModel.Brand,
            price: filterModel.Price,
            created: filterModel.Created,
            pageSize,
            pageIndex,
            args.Search,
            args.OrderBy);
        products = result.ToListViewModel();
        this.StateHasChanged();
    }

    private async Task Filter()
    {
        if (this.filterContext.Validate())
        {
            await LoadData(new LoadDataEventArgs
            {
                PageIndex = 1,
                PageSize = this.pageSize,
                Search = filterModel.Search,
                OrderBy = filterModel.OrderBy,
            });
        }
    }

    private void ClearFilter()
    {
        filterModel = new();
        this.filterContext = new EditContext(filterModel);
        this.StateHasChanged();
    }

    private void NavigateToCreate()
    {
        this.Navigation.NavigateTo("/product/add");
    }

    private void NavigateToUpdate(ProductViewModel item)
    {
        this.Navigation.NavigateTo($"/product/edit/{item.Id}");
    }
}
