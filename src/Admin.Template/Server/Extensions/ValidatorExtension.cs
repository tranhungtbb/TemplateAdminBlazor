namespace Admin.Template.Server.Extensions;

public static class ValidatorExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        //services.AddScoped<IValidator<CreateProductModel>, CreateProductValidator>();
        //services.AddScoped<IValidator<UpdateProductModel>, UpdateProductValidator>();

        services.AddValidatorsFromAssemblyContaining<Startup>();
        return services;
    }
}
