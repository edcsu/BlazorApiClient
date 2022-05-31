using BlazorApiClient;
using BlazorApiClient.Config;
using BlazorApiClient.Services.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

Console.WriteLine("BlazorAPIClient has started...");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var config = builder.Configuration;
var spaceXSettings = config.GetSpaceXSettings();

// determine which API to use default is RESTAPI
switch (spaceXSettings.ApiType)
{
    case ApiType.Graphql:
        builder.Services.AddTransient<ISpaceXDataService, GraphqlSpaceXDataService>();
        break;

    case ApiType.Rest:
    default:
        builder.Services.AddTransient<ISpaceXDataService, SpaceXDataService>();
        break;
}

builder.Services.AddHttpClient("SpaceX", httpClient =>
{
    httpClient.BaseAddress = new Uri(spaceXSettings.BaseUrl!);
});

await builder.Build().RunAsync();
