using System.Runtime.Serialization;

namespace Unionized.Contract
{
    [DataContract]
    public  class EntityAttributes
    {
        public EntityAttributes()
        {

        }

        [DataMember]
        public bool? Editable { get; set; }

        [DataMember]
        public string FriendlyName { get; set; }

        [DataMember]
        public string Icon { get; set; }

        #region Switch

        [DataMember]
        public double? CurrentA { get; set; }

        [DataMember]
        public string CurrentPowerW { get; set; }

        [DataMember]
        public string TodayEnergyKwh { get; set; }

        [DataMember]
        public string TotalEnergyKwh { get; set; }

        [DataMember]
        public string Voltage { get; set; }
        #endregion

        #region Zone
        [DataMember]
        public bool? Hidden { get; set; }

        [DataMember]
        public double? Latitude { get; set; }

        [DataMember]
        public double? Longitude { get; set; }

        [DataMember]
        public bool? Passive { get; set; }

        [DataMember]
        public long? Radius { get; set; }
        #endregion
    }
}
