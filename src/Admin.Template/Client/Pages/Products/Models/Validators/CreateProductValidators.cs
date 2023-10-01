
using Admin.Template.Client.Models;
using Admin.Template.Client.Pages.Products.Models;
using FluentValidation;

namespace Admin.Template.Client.Pages.Products.Validators;

public class CreateProductValidators : ValidatorBase<CreateProductViewModel>
{
    public CreateProductValidators()
    {
        this.RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is mandatory")
            .MaximumLength(250);

        this.RuleFor(x =>x.Price)
            .NotNull()
            .WithMessage("Price is mandatory")
            .GreaterThan(0);

        this.RuleFor(x =>x.Description)
            .NotEmpty()
            .WithMessage("Description is mandatory");
    }
}