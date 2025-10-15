using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TripPlannerApp;
using TripPlannerApp.Services;
using Blazored.LocalStorage;
using WeatherApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<CitySuggestionService>();


// ✅ Plain HttpClient for external APIs
builder.Services.AddScoped(sp => new HttpClient());

// ✅ Register services
builder.Services.AddScoped<ILocationService, GeolocationService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<CitySuggestionService>();
builder.Services.AddBlazoredLocalStorage();

// ✅ OpenWeather API
var openWeatherApiKey = "b19e2b255e902a5581acc442253764a0";
builder.Services.AddScoped<IWeatherService>(sp =>
{
    var http = sp.GetRequiredService<HttpClient>();
    return new OpenWeatherService(http, openWeatherApiKey);
});

await builder.Build().RunAsync();