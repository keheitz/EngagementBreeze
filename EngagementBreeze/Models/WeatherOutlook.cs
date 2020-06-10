using EngagementBreeze.OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EngagementBreeze.Models
{
    public class WeatherOutlook
    {
        /// <summary>
        /// Provides baseline to convert unix timestamp to local time
        /// </summary>
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public List<DailyForecast> forecasts { get; set; } = new List<DailyForecast>();

        /// <summary>
        /// Constructor which populates the daily forecast with only the variables we care about based on the OpenWeatherAPI 5 day forecast response
        /// </summary>
        /// <param name="response">OpenWeatherAPI 5 day forecast</param>
        public WeatherOutlook(FiveDayForecastResponse response, int sunshineThreshold, int rainyThreshold)
        {
            forecasts =
                (from weatherItem in response.list
                 group weatherItem by UnixEpoch.AddSeconds(weatherItem.dt).Date into forecastDate
                 select new DailyForecast
                 {
                     ForecastDate = forecastDate.Key,
                     AverageTemperature = GetAverageTemperature(forecastDate),
                     Sunny = CheckIfSunny(sunshineThreshold, forecastDate),
                     Rainy = CheckIfRainy(rainyThreshold, forecastDate)
                 }).ToList();
        }

        private bool CheckIfRainy(int rainyThreshold, IGrouping<DateTime, List> forecastDate)
        {
            return GetPercentageRainy(forecastDate.SelectMany(x => x.weather).Select(w => w.main).ToList()) > rainyThreshold;
        }

        private static bool CheckIfSunny(int sunshineThreshold, IGrouping<DateTime, List> forecastDate)
        {
            return forecastDate.Average(x => x.clouds.all) < sunshineThreshold;
        }

        private static float GetAverageTemperature(IGrouping<DateTime, List> forecastDate)
        {
            return forecastDate.Average(x => x.main.temp);
        }

        /// <summary>
        /// Takes in the main weather tag for the day and returns the percentage of those that contain "rain"
        /// </summary>
        /// <param name="list">List of the weather parameters from the measurements for that date</param>
        /// <returns>Percentage as an integer 1-100</returns>
        private int GetPercentageRainy(List<string> list)
        {
            decimal rainyCount = list.Where(x => x.ToLower() == "rain").Count();
            decimal total = list.Count();
            return Convert.ToInt32((rainyCount / total) * 100);
        }
    }

}