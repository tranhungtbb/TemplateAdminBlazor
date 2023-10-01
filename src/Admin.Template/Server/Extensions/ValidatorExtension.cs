using FluentValidation.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Admin.Template.Server.Extensions;

public static class ValidatorExtension
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Startup>();
        return services;
    }

    public static string ValidationResult(this ValidationException validation)
    {
        var failures = validation.Errors
            .Select(error => new ValidationFailure(error.PropertyName, error.ErrorMessage))
            .ToList();

        var setting = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
        };

        return JsonConvert.SerializeObject(new ValidationResult(failures), setting);
    }
}
