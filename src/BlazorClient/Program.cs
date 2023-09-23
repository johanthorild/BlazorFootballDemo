using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using BlazorClient;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient("FootballApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FootballApi:Url"]);
    client.DefaultRequestHeaders.Add("x-apisports-key", builder.Configuration["FootballApi:Key"]);
});

await builder.Build().RunAsync();
