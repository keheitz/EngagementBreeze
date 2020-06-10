using System.Collections.Generic;

namespace EngagementBreeze.OpenWeatherAPI
{
    public class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        /// <summary>
        /// Time of data forecasted, UTC, unix timestamp
        /// </summary>
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
        public Snow snow { get; set; }
    }

}