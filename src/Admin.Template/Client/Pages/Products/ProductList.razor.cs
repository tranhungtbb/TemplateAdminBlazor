namespace Admin.Template.Client.Pages.Products;

public partial class ProductList : PageBase
{
    private dynamic products;
    private int pageSize = 10 , pageIndex = 1;

    [Inject]
    private ProductsClient ProductsClient { get; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            var ss = await ProductsClient.ListAsync(pageSize, pageIndex, null, null);
        }
    }
}
