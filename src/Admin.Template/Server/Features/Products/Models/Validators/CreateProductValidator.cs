using Admin.Template.Server.Data;

namespace Admin.Template.Server.Features.Products.Models.Validators;

public class CreateProductValidator : ValidatorBase<CreateProductModel>
{
    public CreateProductValidator(ApplicationDbContext context) : base(context)
    {
        this.RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(ValidatorConstants.MaxNameLength);

        this.RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Price must greater than 0");
    }
}
