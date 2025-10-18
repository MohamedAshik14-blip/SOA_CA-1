using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TripPlannerApp;
using TripPlannerApp.Services;

using WeatherApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient());

builder.Services.AddScoped<ILocationService, GeolocationService>();
builder.Services.AddScoped<ICountryService, CountryService>();


var openWeatherApiKey = "b19e2b255e902a5581acc442253764a0";
builder.Services.AddScoped<IWeatherService>(sp =>
{
    var http = sp.GetRequiredService<HttpClient>();
    return
});

await builder.Build().RunAsync();
