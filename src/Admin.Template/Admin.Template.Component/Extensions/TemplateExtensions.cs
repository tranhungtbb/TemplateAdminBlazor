using Microsoft.Extensions.DependencyInjection;
using Admin.Template.Component.Services;

namespace Admin.Template.Component.Extensions;

public static class TemplateExtensions
{
	public static IServiceCollection UseComponentService(this IServiceCollection services)
	{
		services.AddScoped<ToastService>();
		return services;
	}
}
