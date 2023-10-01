using Admin.Template.Server.Data;
using FluentValidation.Results;

namespace Admin.Template.Server.Models;

public class ValidatorBase<T> : AbstractValidator<T> where T : EntityBase
{
    protected readonly ApplicationDbContext Context;

    public ValidatorBase(ApplicationDbContext context)
    {
        this.Context = context;
    }

    protected override void RaiseValidationException(ValidationContext<T> context, ValidationResult result)
    {
        throw new ValidationException(result.Errors);
    }
}
