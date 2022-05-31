using BlazorApiClient;
using BlazorApiClient.Config;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

Console.WriteLine("BlazorAPIClient has started...");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var config = builder.Configuration;
var spaceXSettings = config.GetSpaceXSettings();

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri(spaceXSettings.BaseUrl!) 
});

await builder.Build().RunAsync();
