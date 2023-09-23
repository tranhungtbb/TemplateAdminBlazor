using Admin.Template.Server.Data;

namespace Admin.Template.Server.Models;

public class ValidatorBase<T> : AbstractValidator<T> where T : EntityBase
{
    private readonly ApplicationDbContext Context;

    public ValidatorBase(ApplicationDbContext context)
    {
        this.Context = context;
    }
}
