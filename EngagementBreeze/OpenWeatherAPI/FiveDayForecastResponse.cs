using System.Collections.Generic;

namespace EngagementBreeze.OpenWeatherAPI
{

    /// <summary>
    /// Class mapping of JSON response
    /// API endpoint documentation available at http://openweathermap.org/forecast5
    /// </summary>
    public class FiveDayForecastResponse
    {
        /// <summary>
        /// Internal Open Weather API parameter
        /// </summary>
        public string cod { get; set; }

        /// <summary>
        /// Internal Parameter
        /// </summary>
        public int message { get; set; }

        /// <summary>
        /// Number of lines returned by this API call
        /// </summary>
        public int cnt { get; set; }

        /// <summary>
        /// Contains forecasted weather data
        /// </summary>
        public List<List> list { get; set; }

        /// <summary>
        /// Contains identifying information for the city to which the forecast applies
        /// </summary>
        public City city { get; set; }
    }

}