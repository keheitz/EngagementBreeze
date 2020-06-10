using EngagementBreeze.Models;
using EngagementBreeze.OpenWeatherAPI;
using RestSharp;
using System;
using System.Drawing;
using System.Net;
using System.Text.Json;
using Console = Colorful.Console;

namespace EngagementBreeze.Commands
{
    class RecommendCommand : Command
    {
        public override void Execute()
        {
            FiveDayForecastResponse fiveDayForecast = GetForecast();
            if (fiveDayForecast != null)
            {
                WeatherOutlook weatherOutlook = GetWeatherOutlook(fiveDayForecast);
                EngagementRecommendation recommendation = new EngagementRecommendation(weatherOutlook);
                recommendation.WritePlan();
            }
        }

        public override string GetDefinition() => "get recommended contact method to engage customer based on the forecast weather for upcoming 5 days";

        public override string GetFormat() => GetName();

        public override string GetName() => "recommend";

        private static WeatherOutlook GetWeatherOutlook(FiveDayForecastResponse fiveDayForecast)
        {
            var sunnyThreshold = Int32.Parse(ApplicationSettings.GetInstance().GetSettingValue(ConfigurableSettings.SunnyThreshold));
            var rainyThreshold = Int32.Parse(ApplicationSettings.GetInstance().GetSettingValue(ConfigurableSettings.RainyThreshold));
            WeatherOutlook weatherOutlook = new WeatherOutlook(fiveDayForecast, sunnyThreshold, rainyThreshold);
            return weatherOutlook;
        }

        private static FiveDayForecastResponse GetForecast()
        {
            IRestResponse response = CallOpenWeatherApi();
            FiveDayForecastResponse fiveDayForecast = null;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"API Error: {response.StatusCode} - {response.Content}", Color.Red);
            }
            else // Only attempt to deserialize if we got an okay response
            {
                try
                {
                    fiveDayForecast = JsonSerializer.Deserialize<FiveDayForecastResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Deserialization error: {ex.Message}", Color.Red);
                }
            }
            return fiveDayForecast;
        }

        private static IRestResponse CallOpenWeatherApi()
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/");
            client.Timeout = -1;
            var request = new RestRequest("forecast", Method.GET);
            request.AddParameter("q", $"{ApplicationSettings.GetInstance().GetSettingValue(ConfigurableSettings.City)},US");
            request.AddParameter("appid", ApplicationSettings.GetInstance().GetSettingValue(ConfigurableSettings.ApiKey));
            request.AddParameter("units", "imperial");// default temp is in Kelvin, we want to get it in fahrenheit
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
