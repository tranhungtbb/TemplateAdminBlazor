﻿using Admin.Template.Server.Middlewares;

namespace Admin.Template.Server.Extensions;

public static class DIExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ExceptionHandlingMiddleware>();

        services.AddHttpContextAccessor();
        services.AddTransient(s => s.GetRequiredService<IHttpContextAccessor>().HttpContext?.User ?? new System.Security.Claims.ClaimsPrincipal());
        return services;
    }
}
