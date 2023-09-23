using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Admin.Template.Client;
using Admin.Template.Component.Extensions;
using Admin.Template.Client.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string httpClientName = "Admin.Template.ServerAPI";

builder.Services.AddHttpClient(httpClientName,
    client =>
    {
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    })
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(httpClientName));

builder.Services.AddApiClients(httpClientName);

builder.Services.AddApiAuthorization();
builder.Services.UseComponentService();

await builder.Build().RunAsync();
