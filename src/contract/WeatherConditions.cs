using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public class WeatherConditions
    {
        /// <summary>
        /// Current temperature in celsius
        /// </summary>
        [DataMember]
        public double CurrentTemperature { get; set; }

        /// <summary>
        /// Current pressure in milibar
        /// </summary>
        [DataMember]
        public double CurrentPressure { get; set; }

        /// <summary>
        /// The relative humidity like 85%
        /// </summary>
        [DataMember]
        public byte RelativeHumidity { get; set; }

        /// <summary>
        /// Maximum temperature forecasted in celsius
        /// </summary>
        [DataMember]
        public double MaximumTemperature { get; set; }

        /// <summary>
        /// Minimum temperature forecasted in celsius
        /// </summary>
        [DataMember]
        public double MinimumTemperature { get; set; }

        /// <summary>
        /// Visibility in kilometers
        /// </summary>
        [DataMember]
        public double Visibility { get; set; }

        /// <summary>
        /// Accumulated rain totals in an hour
        /// </summary>
        [DataMember]
        public double? RainTotal { get; set; }

        [DataMember]
        public double WindSpeed { get; set; }

        [DataMember]
        public short WindDirection { get; set; }

        [DataMember]
        public byte CloudCover { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public DateTime Sunrise { get; set; }

        [DataMember]
        public DateTime Sunset { get; set; }

        [DataMember]
        public TimeSpan LengthOfDay => Sunset - Sunrise;

        [DataMember]
        public int StationId { get; set; }

        [DataMember]
        public List<WeatherDescription> Weather { get; set; }
    }

    [DataContract]
    public sealed class WeatherDescription
    {
        public string Brief { get; set; }

        public string Detailed { get; set; }

        public string WeatherIcon { get; set; }
    }
}
