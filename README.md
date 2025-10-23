🌤️ Weather & Trip Planner – SOA_CA-1

Project Overview

Weather & Trip Planner is a Blazor Web Application built in C# for the SD4 SOA module.
It allows users to:
	•	Search for countries and cities info
	•	View real-time weather and 3-day forecasts
	•	Explore top cities with population and distance filters
	•	Save favorites for quick access

This project demonstrates Service-Oriented Architecture (SOA) principles using multiple RESTful web services, integrating them into a contextualized trip-planning domain.

⸻

APIs Used

1. REST Countries API
	•	URL: https://restcountries.com/v3.1/
	•	Purpose: Fetches country details like population, region, area, and flag for contextual info.
	•	Used In: CountryService.cs

2. OpenWeatherMap API
	•	URL: https://openweathermap.org/api
	•	Purpose: Provides current weather data and 3-day forecasts (temperature, description, and condition type).
	•	Used In: WeatherService.cs

3. GeoDB Cities API
	•	URL: https://rapidapi.com/wirefreethought/api/geodb-cities/
	•	Purpose: Supplies city data such as name, population, latitude, longitude, and country.
	•	Used In: CityService.cs

⸻

Key Features
	•	Explore Global Cities: View population, distance, and weather details for cities worldwide.
	•	Live Weather Updates: Displays current conditions and 3-day forecasts via OpenWeather API.
	•	Favorites Management: Save and remove favorite countries or cities (via LocalStorage).
	•	Distance Filter: Filter nearby cities based on location radius.
	•	Sorting & Filtering: Sort by population, temperature, or distance.
	•	Modular Architecture: Uses clean service classes and dependency injection.

⸻

References & Credits

Official Documentation:
	•	Microsoft Blazor Documentation (https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-9.0)
	•	OpenWeatherMap API Docs(https://openweathermap.org/api)
	•	REST Countries API Docs(https://restcountries.com/)
	•	GeoDB Cities API Docs(https://geodb-cities-api.wirefreethought.com/)

Tutorials / Code References:
	•	StackOverflow: Get Data From External API with Blazor WASM (https://stackoverflow.com/questions/66824354/get-data-from-external-api-with-blazor-wasm)
	•	StackOverflow: Blazor WebAssembly - Calling External API (https://stackoverflow.com/questions/62398811/blazor-webassembly-calling-external-api)
	•	StackOverflow: Blazor WebAssembly Third Party API (https://stackoverflow.com/questions/65951330/blazor-webassembly-third-party-api)
  •	YouTube Tutorial: Blazor WebAssembly + REST API Integration (https://www.youtube.com/watch?v=7C9c_-nXoNo)
	•	Blazored.LocalStorage GitHub Repository (https://github.com/Blazored/LocalStorage)

