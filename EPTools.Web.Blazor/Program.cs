using EPTools.Web.Blazor;
using EPTools.Common.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<FetchService>();
builder.Services.AddScoped<StatBlockTemplateService>();
builder.Services.AddScoped<EPDataService>();
builder.Services.AddScoped<DiscordWebhookService>();
await builder.Build().RunAsync();
