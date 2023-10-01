using Admin.Template.Client.Pages.Products.Models;
using Admin.Template.Client.Pages.Products.Validators;
using Admin.Template.Component.Services;
using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

namespace Admin.Template.Client.Pages.Products;

public partial class Add : PageBase
{
    private CreateProductViewModel model = new();

    [Inject]
    public ToastService ToastService { get; set; }

    [Inject]
    private ProductsClient ProductsClient { get; set; }

    [Inject]
    private IValidator<CreateProductViewModel> Validator { get; set; }

    private EditContext Context { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        this.Context = new EditContext(model);
    }

    public async Task OnSubmit()
    {
        if (this.Context.Validate())
        {
            await ProductsClient.InsertAsync(new CreateProductModel
            {
                Name = model.Name,
                Description = model.Description,
                Brand = model.Brand,
                Unit = model.Unit,
                Price = model.Price ?? 0,
            });

            await this.ToastService.ShowToast("Insert product successfully!");
            this.Navigation.NavigateTo("/product/lists");
        }
    }
}