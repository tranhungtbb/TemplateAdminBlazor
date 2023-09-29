namespace Admin.Template.Client.Pages.Products.Models;

public static class ModelExtensions
{
    public static ListProductViewModel ToListViewModel(this PagedResultModelOfProductModel model)
    {
        return new ListProductViewModel
        {
            Items = model.Items.Select(x => x.ToViewModel()).ToList(),
            PageSize = model.PageSize,
            PageIndex = model.PageIndex,
            TotalCount = model.TotalCount,
        };
    }

    public static ProductViewModel ToViewModel(this ProductModel model)
    {
        return new ProductViewModel
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Unit = model.Unit,
            Brand = model.Brand,
            Price = model.Price,
            Created = model.Created,
            ModifyDate = model.ModifyDate,
        };
    }
}
