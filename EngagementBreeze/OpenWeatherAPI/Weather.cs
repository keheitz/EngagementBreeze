namespace EngagementBreeze.OpenWeatherAPI
{
    public class Weather
    {
        public int id { get; set; }
        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        public string main { get; set; }
        /// <summary>
        /// Weather condition within the group
        /// </summary>
        public string description { get; set; }
        public string icon { get; set; }
    }

}