/*
 * openHAB REST API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Unionized.Model.API.OpenHab
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ThingDTO : IEquatable<ThingDTO>
    { 
        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name="label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets BridgeUID
        /// </summary>
        [DataMember(Name="bridgeUID")]
        public string BridgeUID { get; set; }

        /// <summary>
        /// Gets or Sets Configuration
        /// </summary>
        [DataMember(Name="configuration")]
        public Dictionary<string, Object> Configuration { get; set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name="properties")]
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Gets or Sets UID
        /// </summary>
        [DataMember(Name="UID")]
        public string UID { get; set; }

        /// <summary>
        /// Gets or Sets ThingTypeUID
        /// </summary>
        [DataMember(Name="thingTypeUID")]
        public string ThingTypeUID { get; set; }

        /// <summary>
        /// Gets or Sets Channels
        /// </summary>
        [DataMember(Name="channels")]
        public List<ChannelDTO> Channels { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name="location")]
        public string Location { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ThingDTO {\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  BridgeUID: ").Append(BridgeUID).Append("\n");
            sb.Append("  Configuration: ").Append(Configuration).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  UID: ").Append(UID).Append("\n");
            sb.Append("  ThingTypeUID: ").Append(ThingTypeUID).Append("\n");
            sb.Append("  Channels: ").Append(Channels).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ThingDTO)obj);
        }

        /// <summary>
        /// Returns true if ThingDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of ThingDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ThingDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Label == other.Label ||
                    Label != null &&
                    Label.Equals(other.Label)
                ) && 
                (
                    BridgeUID == other.BridgeUID ||
                    BridgeUID != null &&
                    BridgeUID.Equals(other.BridgeUID)
                ) && 
                (
                    Configuration == other.Configuration ||
                    Configuration != null &&
                    Configuration.SequenceEqual(other.Configuration)
                ) && 
                (
                    Properties == other.Properties ||
                    Properties != null &&
                    Properties.SequenceEqual(other.Properties)
                ) && 
                (
                    UID == other.UID ||
                    UID != null &&
                    UID.Equals(other.UID)
                ) && 
                (
                    ThingTypeUID == other.ThingTypeUID ||
                    ThingTypeUID != null &&
                    ThingTypeUID.Equals(other.ThingTypeUID)
                ) && 
                (
                    Channels == other.Channels ||
                    Channels != null &&
                    Channels.SequenceEqual(other.Channels)
                ) && 
                (
                    Location == other.Location ||
                    Location != null &&
                    Location.Equals(other.Location)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                    if (BridgeUID != null)
                    hashCode = hashCode * 59 + BridgeUID.GetHashCode();
                    if (Configuration != null)
                    hashCode = hashCode * 59 + Configuration.GetHashCode();
                    if (Properties != null)
                    hashCode = hashCode * 59 + Properties.GetHashCode();
                    if (UID != null)
                    hashCode = hashCode * 59 + UID.GetHashCode();
                    if (ThingTypeUID != null)
                    hashCode = hashCode * 59 + ThingTypeUID.GetHashCode();
                    if (Channels != null)
                    hashCode = hashCode * 59 + Channels.GetHashCode();
                    if (Location != null)
                    hashCode = hashCode * 59 + Location.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ThingDTO left, ThingDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ThingDTO left, ThingDTO right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
