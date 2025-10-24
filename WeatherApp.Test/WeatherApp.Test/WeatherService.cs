using Moq;
using WeatherApp.Models;
using WeatherApp.Services;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WeatherApp.Test
{
    public class WeatherServiceTests
    {
        [Fact]
        public async Task GetForecastAsync_ReturnsListOfWeatherInfo()
        {
           
            var mockService = new Mock<IWeatherService>();
            mockService.Setup(s => s.GetForecastAsync(53.0, -6.0))
                .ReturnsAsync(new List<WeatherInfo>
                {
                    new WeatherInfo { Date = System.DateTime.Today, TemperatureC = 15, Type = WeatherType.Sunny }
                });

         
            var result = await mockService.Object.GetForecastAsync(53.0, -6.0);

       
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(15, result[0].TemperatureC);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ReturnsWeatherInfo()
        {
          
            var mockService = new Mock<IWeatherService>();
            mockService.Setup(s => s.GetCurrentWeatherAsync("Dublin"))
                .ReturnsAsync(new WeatherInfo { Date = System.DateTime.Today, TemperatureC = 10, Type = WeatherType.Cloudy });

   
            var weather = await mockService.Object.GetCurrentWeatherAsync("Dublin");

         
            Assert.NotNull(weather);
            Assert.Equal(10, weather.TemperatureC);
            Assert.Equal(WeatherType.Cloudy, weather.Type);
        }
    }
}