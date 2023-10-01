using FluentValidation;

namespace Admin.Template.Client.Models;

public class ValidatorBase<T> : AbstractValidator<T> where T : EntityBase
{
    
}