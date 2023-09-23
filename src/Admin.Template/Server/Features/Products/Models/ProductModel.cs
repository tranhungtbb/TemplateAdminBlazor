namespace Admin.Template.Server.Features.Products.Models;

public class ProductModel: EntityBase, IHasTrace, IHasIsDeleted, IHasCreationTime, IHasModifyTime
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string? Brand { get; set; }
    public decimal Price { get; set; }
    public long? CreateBy { get; set; }
    public string CreateByName { get; set; }
    public long? ModifyBy { get; set; }
    public string ModifyByName { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? ModifyDate { get; set; }
    public DateTime Created { get; set; }
}
