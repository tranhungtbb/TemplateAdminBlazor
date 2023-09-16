using Microsoft.Extensions.DependencyInjection;
using Admin.Template.Component.Services;

namespace Template.Admin.Component.Extensions;

public static class TemplateExtensions
{
	public static IServiceCollection UseComponetService(this IServiceCollection services)
	{
		services.AddScoped<ToastService>();
		return services;
	}
}
