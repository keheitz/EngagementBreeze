using System;
using System.Collections.Generic;

namespace EngagementBreeze.Models
{
    internal class EngagementRecommendation
    {
        /// <summary>
        /// For a given daily forecast sequence, this dictionary summarizes the recommended contact method
        /// Dictionary to ensure only 1 method can be set per date (date is unique key)
        /// </summary>
        private Dictionary<DateTime, ContactMethod> RecommendedContactForDate = new Dictionary<DateTime, ContactMethod>();

        /// <summary>
        /// Applies product rules to make a recommendation for how to engage customers on a given day based on the weather outlook
        /// </summary>
        /// <param name="outlook">Accepts input parameter of the weather outlook</param>
        public EngagementRecommendation(WeatherOutlook outlook)
        {
            foreach(var day in outlook.forecasts)
            {
                ContactMethod contactMethod = new ContactMethod();
                if(day.AverageTemperature < 55 || day.Rainy)
                {
                    contactMethod = ContactMethod.Call;
                }
                else if(day.AverageTemperature <= 75 && day.AverageTemperature >= 55)
                {
                    contactMethod = ContactMethod.Email;
                }
                else if(day.AverageTemperature > 75 && day.Sunny)
                {
                    contactMethod = ContactMethod.Text;
                }
                RecommendedContactForDate.Add(day.ForecastDate, contactMethod);
            }
        }

        public void WritePlan()
        {
            Console.WriteLine("Recommendations based on current weather forecast:");
            Console.WriteLine("--------------------------------------------------");
            foreach (var recommendation in RecommendedContactForDate)
            {
                Console.WriteLine($"{recommendation.Key.ToString("d")}\t{recommendation.Value}");
            }
            Console.WriteLine("--------------------------------------------------");
        }
    }
}