namespace Admin.Template.Client.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddApiClient<T>(this IServiceCollection services, string clientName)
        where T : ClientBase
    {
        services.AddSingleton<T>(sp =>
        {
            var httpClient = sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient(clientName);
            return Activator.CreateInstance(typeof(T), httpClient) as T;
        });

        return services;
    }

    // todo automatic inject from assembly
    public static IServiceCollection AddApiClients(this IServiceCollection services, string clientName)
    {
        services.AddSingleton<ProductsClient>(serviceProvider =>
        {
            var httpClient = serviceProvider.GetRequiredService<IHttpClientFactory>()
                .CreateClient(clientName);
            return new ProductsClient(httpClient.BaseAddress.AbsoluteUri, httpClient);
        });
        return services;
    }
}
