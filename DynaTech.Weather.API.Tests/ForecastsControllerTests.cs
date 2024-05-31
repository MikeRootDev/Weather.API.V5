using DynaTech.Weather.API.Controllers;
using DynaTech.Weather.Domain;
using DynaTech.Weather.Domain.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.Logging;
using Moq;

namespace DynaTech.Weather.API.Tests
{
    [TestClass]
    public class ForecastsControllerTests
    {
        private readonly Mock<ILogger<ForecastsController>> _loggerMock = new Mock<ILogger<ForecastsController>>();
        private readonly Mock<WeatherForecastsService> _weatherForecastsServiceMock = new Mock<WeatherForecastsService>();

        [TestMethod]
        public void Get_HappyPath()
        {
            // Arrange
            ForecastsController _controllerUnderTest = new ForecastsController(_loggerMock.Object, _weatherForecastsServiceMock.Object);
            _weatherForecastsServiceMock.Setup(x => x.GetWeatherForecasts()).Returns(new List<WeatherForecast> { new WeatherForecast { } }).Verifiable();

            // Act
            var forecasts = _controllerUnderTest.Get();

            // Assert
            using (new AssertionScope())
            {
                forecasts.Should().NotBeNull();
                forecasts.Count().Should().Be(1);

                _weatherForecastsServiceMock.Verify(x => x.GetWeatherForecasts(), Times.Once());
            }
        }
    }
}