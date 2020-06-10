using System;

namespace EngagementBreeze.Models
{
    public class DailyForecast
    {
        /// <summary>
        /// Datetime in local time
        /// </summary>
        public DateTime ForecastDate { get; set; }

        /// <summary>
        /// Average real temperature from 3 hour predictions for date
        /// </summary>
        public float AverageTemperature { get; set; }

        /// <summary>
        /// True if the percentage of weather descriptions for the day contain rain more than the configurable rain threshold
        /// </summary>
        public bool Rainy { get; set; }

        /// <summary>
        /// True if the average overall cloudiness of measurements for the day is less than the configurable sun threshold
        /// </summary>
        public bool Sunny { get; set; }

    }

}