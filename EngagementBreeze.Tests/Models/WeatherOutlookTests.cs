using EngagementBreeze.Models;
using EngagementBreeze.OpenWeatherAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EngagementBreeze.ModelsTests
{
    [TestClass]
    public class WeatherOutlookTests
    {
        /// <summary>
        /// Contains sample response with simplified values for 4 list items within one day
        /// </summary>
        string testResponse = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "OpenWeatherAPI_FiveDayForecastResponse.json"));

        [TestMethod]
        public void DailyForecast_ReturnsExpectedResult_AverageTemperature()
        {
            FiveDayForecastResponse response = JsonSerializer.Deserialize<FiveDayForecastResponse>(testResponse);
            WeatherOutlook weatherOutlook = new WeatherOutlook(response, 50, 50);

            Assert.AreEqual(weatherOutlook.forecasts.FirstOrDefault()?.AverageTemperature, 60);
        }

        [TestMethod]
        public void DailyForecast_ReturnsExpectedResult_Rainy()
        {
            FiveDayForecastResponse response = JsonSerializer.Deserialize<FiveDayForecastResponse>(testResponse);
            WeatherOutlook weatherOutlook = new WeatherOutlook(response, 50, 50);

            Assert.IsTrue(weatherOutlook.forecasts.FirstOrDefault().Rainy);
        }

        [TestMethod]
        public void DailyForecast_ReturnsExpectedResult_NotRainy()
        {
            FiveDayForecastResponse response = JsonSerializer.Deserialize<FiveDayForecastResponse>(testResponse);
            //Set rainy threshold higher than our test data returns to ensure thresholds are mapped correctly
            WeatherOutlook weatherOutlook = new WeatherOutlook(response, 50, 90);

            Assert.IsFalse(weatherOutlook.forecasts.FirstOrDefault().Rainy);
        }

        [TestMethod]
        public void DailyForecast_ReturnsExpectedResult_Sunny()
        {
            FiveDayForecastResponse response = JsonSerializer.Deserialize<FiveDayForecastResponse>(testResponse);
            WeatherOutlook weatherOutlook = new WeatherOutlook(response, 90, 50);

            Assert.IsTrue(weatherOutlook.forecasts.FirstOrDefault().Sunny);
        }

        [TestMethod]
        public void DailyForecast_ReturnsExpectedResult_NotSunny()
        {
            FiveDayForecastResponse response = JsonSerializer.Deserialize<FiveDayForecastResponse>(testResponse);
            WeatherOutlook weatherOutlook = new WeatherOutlook(response, 50, 50);

            Assert.IsFalse(weatherOutlook.forecasts.FirstOrDefault().Sunny);
        }
    }
}
