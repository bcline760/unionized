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
    public partial class ChannelDTO : IEquatable<ChannelDTO>
    { 
        /// <summary>
        /// Gets or Sets Uid
        /// </summary>
        [DataMember(Name="uid")]
        public string Uid { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ChannelTypeUID
        /// </summary>
        [DataMember(Name="channelTypeUID")]
        public string ChannelTypeUID { get; set; }

        /// <summary>
        /// Gets or Sets ItemType
        /// </summary>
        [DataMember(Name="itemType")]
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or Sets Kind
        /// </summary>
        [DataMember(Name="kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name="label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets DefaultTags
        /// </summary>
        [DataMember(Name="defaultTags")]
        public List<string> DefaultTags { get; set; }

        /// <summary>
        /// Gets or Sets Properties
        /// </summary>
        [DataMember(Name="properties")]
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Gets or Sets Configuration
        /// </summary>
        [DataMember(Name="configuration")]
        public Dictionary<string, Object> Configuration { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChannelDTO {\n");
            sb.Append("  Uid: ").Append(Uid).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ChannelTypeUID: ").Append(ChannelTypeUID).Append("\n");
            sb.Append("  ItemType: ").Append(ItemType).Append("\n");
            sb.Append("  Kind: ").Append(Kind).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DefaultTags: ").Append(DefaultTags).Append("\n");
            sb.Append("  Properties: ").Append(Properties).Append("\n");
            sb.Append("  Configuration: ").Append(Configuration).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ChannelDTO)obj);
        }

        /// <summary>
        /// Returns true if ChannelDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of ChannelDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Uid == other.Uid ||
                    Uid != null &&
                    Uid.Equals(other.Uid)
                ) && 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    ChannelTypeUID == other.ChannelTypeUID ||
                    ChannelTypeUID != null &&
                    ChannelTypeUID.Equals(other.ChannelTypeUID)
                ) && 
                (
                    ItemType == other.ItemType ||
                    ItemType != null &&
                    ItemType.Equals(other.ItemType)
                ) && 
                (
                    Kind == other.Kind ||
                    Kind != null &&
                    Kind.Equals(other.Kind)
                ) && 
                (
                    Label == other.Label ||
                    Label != null &&
                    Label.Equals(other.Label)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) && 
                (
                    DefaultTags == other.DefaultTags ||
                    DefaultTags != null &&
                    DefaultTags.SequenceEqual(other.DefaultTags)
                ) && 
                (
                    Properties == other.Properties ||
                    Properties != null &&
                    Properties.SequenceEqual(other.Properties)
                ) && 
                (
                    Configuration == other.Configuration ||
                    Configuration != null &&
                    Configuration.SequenceEqual(other.Configuration)
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
                    if (Uid != null)
                    hashCode = hashCode * 59 + Uid.GetHashCode();
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (ChannelTypeUID != null)
                    hashCode = hashCode * 59 + ChannelTypeUID.GetHashCode();
                    if (ItemType != null)
                    hashCode = hashCode * 59 + ItemType.GetHashCode();
                    if (Kind != null)
                    hashCode = hashCode * 59 + Kind.GetHashCode();
                    if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    if (DefaultTags != null)
                    hashCode = hashCode * 59 + DefaultTags.GetHashCode();
                    if (Properties != null)
                    hashCode = hashCode * 59 + Properties.GetHashCode();
                    if (Configuration != null)
                    hashCode = hashCode * 59 + Configuration.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ChannelDTO left, ChannelDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChannelDTO left, ChannelDTO right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}