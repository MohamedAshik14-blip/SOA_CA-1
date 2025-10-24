using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using WeatherApp.Models;
using WeatherApp.Services;
using Xunit;

namespace WeatherApp.Test
{
    public class CountryServiceTests
    {
        [Fact]
        public async Task GetCountryInfoAsync_ReturnsCountry_WhenValidName()
        {
           
            var country = new CountryInfo
            {
                Name = new NameInfo { Common = "Ireland" },
                Region = "Europe",
                Population = 5000000
            };
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(new[] { country })
                });

            var client = new HttpClient(httpMessageHandlerMock.Object);
            var service = new CountryService(client);

         
            var result = await service.GetCountryInfoAsync("Ireland");

            
            Assert.NotNull(result);
            Assert.Equal("Ireland", result?.Name.Common);
            Assert.Equal("Europe", result?.Region);
        }

        [Fact]
        public async Task GetCountryInfoAsync_ReturnsNull_WhenEmptyName()
        {
            var client = new HttpClient();
            var service = new CountryService(client);

            
            var result = await service.GetCountryInfoAsync("");

            
            Assert.Null(result);
        }
    }
}
