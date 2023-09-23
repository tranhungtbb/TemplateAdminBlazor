using Admin.Template.Server.Controllers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Template.Server.Extensions;

public static class ResponseExtensions
{
    public static BadRequestObjectResult Failed(this ApiControllerBase controller, ValidationResult result)
    {
        return new BadRequestObjectResult(result);
    }

    public static BadRequestObjectResult Failed(this ApiControllerBase controller, string message, string propertyName)
    {
        var validationResult = new ValidationResult(
            new List<ValidationFailure>()
            {
                new ValidationFailure(propertyName, message),
            });

        return new BadRequestObjectResult(validationResult);
    }
}
