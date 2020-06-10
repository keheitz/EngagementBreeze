namespace EngagementBreeze.OpenWeatherAPI
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        /// <summary>
        /// Country code (GB, JP, etc.)
        /// </summary>
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

}