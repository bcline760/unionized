using System.Runtime.Serialization;

namespace Unionized.Contract
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum ServiceDomain
    {
        /// <summary>
        /// Service domain for automation service calls
        /// </summary>
        [EnumMember]
        Automation,
        /// <summary>
        /// Service domain pertaining to home API cloud
        /// </summary>
        [EnumMember]
        Cloud,
        /// <summary>
        /// Service domain pertaining to the front end of home API
        /// </summary>
        [EnumMember]
        Frontend,
        [EnumMember]
        Group,
        [EnumMember]
        HassIo,
        [EnumMember]
        HomeAssistant,
        [EnumMember]
        Input_Datetime,
        [EnumMember]
        Input_Boolean,
        [EnumMember]
        Input_Number,
        [EnumMember]
        Input_Select,
        [EnumMember]
        Input_Text,
        [EnumMember]
        LogBook,
        [EnumMember]
        Media_Player,
        [EnumMember]
        Notify,
        [EnumMember]
        Persistent_Notification,
        [EnumMember]
        Person,
        [EnumMember]
        Recorder,
        [EnumMember]
        Remote,
        [EnumMember]
        Roku,
        [EnumMember]
        Scene,
        [EnumMember]
        Script,
        [EnumMember]
        Stream,
        [EnumMember]
        Switch,
        [EnumMember]
        System_Log,
        [EnumMember]
        TTS,
        [EnumMember]
        Zone
    }
}
