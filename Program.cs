using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TripPlannerApp;
using TripPlannerApp.Services;

using WeatherApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient());



builder.Services.AddScoped<ICountryService, CountryService>();


await builder.Build().RunAsync();
