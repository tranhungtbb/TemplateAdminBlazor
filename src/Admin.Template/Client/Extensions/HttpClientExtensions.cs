namespace Admin.Template.Client.Extensions;

public static class HttpClientExtensions
{
    private static IServiceCollection AddApiClient<T>(this IServiceCollection services, string clientName)
        where T : ClientBase
    {
        services.AddSingleton<T>(sp =>
        {
            var httpClient = sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient(clientName);
            return (T)ActivatorUtilities.CreateInstance(services.BuildServiceProvider(), typeof(T), httpClient);
        });

        return services;
    }

    // todo automatic inject from assembly
    public static IServiceCollection AddApiClients(this IServiceCollection services, string clientName)
    {
        services.AddApiClient<ProductsClient>(clientName);
        return services;
    }
}
