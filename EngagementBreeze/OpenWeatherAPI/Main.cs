namespace EngagementBreeze.OpenWeatherAPI
{
    public class Main
    {
        /// <summary>
        /// Measured temperature
        /// Unit default: Kelvin
        /// Metric: Celsius
        /// Imperial: Fahrenheit
        /// </summary>
        public float temp { get; set; }
        /// <summary>
        /// This temperature accounts for the human perception of weather
        /// Unit default: Kelvin
        /// Metric: Celsius
        /// Imperial: Fahrenheit
        /// </summary>
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        /// <summary>
        /// Atmospheric pressure on the sea level by default, hPa
        /// </summary>
        public int pressure { get; set; }
        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public int humidity { get; set; }
        public float temp_kf { get; set; }
    }

}