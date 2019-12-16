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

namespace Unionized.Model.OpenHab
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ChannelTypeDTO : IEquatable<ChannelTypeDTO>
    { 
        /// <summary>
        /// Gets or Sets Parameters
        /// </summary>
        [DataMember(Name="parameters")]
        public List<ConfigDescriptionParameterDTO> Parameters { get; set; }

        /// <summary>
        /// Gets or Sets ParameterGroups
        /// </summary>
        [DataMember(Name="parameterGroups")]
        public List<ConfigDescriptionParameterGroupDTO> ParameterGroups { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name="label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name="category")]
        public string Category { get; set; }

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
        /// Gets or Sets StateDescription
        /// </summary>
        [DataMember(Name="stateDescription")]
        public StateDescription StateDescription { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name="tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or Sets UID
        /// </summary>
        [DataMember(Name="UID")]
        public string UID { get; set; }

        /// <summary>
        /// Gets or Sets Advanced
        /// </summary>
        [DataMember(Name="advanced")]
        public bool? Advanced { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ChannelTypeDTO {\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
            sb.Append("  ParameterGroups: ").Append(ParameterGroups).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  ItemType: ").Append(ItemType).Append("\n");
            sb.Append("  Kind: ").Append(Kind).Append("\n");
            sb.Append("  StateDescription: ").Append(StateDescription).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  UID: ").Append(UID).Append("\n");
            sb.Append("  Advanced: ").Append(Advanced).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ChannelTypeDTO)obj);
        }

        /// <summary>
        /// Returns true if ChannelTypeDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of ChannelTypeDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChannelTypeDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Parameters == other.Parameters ||
                    Parameters != null &&
                    Parameters.SequenceEqual(other.Parameters)
                ) && 
                (
                    ParameterGroups == other.ParameterGroups ||
                    ParameterGroups != null &&
                    ParameterGroups.SequenceEqual(other.ParameterGroups)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) && 
                (
                    Label == other.Label ||
                    Label != null &&
                    Label.Equals(other.Label)
                ) && 
                (
                    Category == other.Category ||
                    Category != null &&
                    Category.Equals(other.Category)
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
                    StateDescription == other.StateDescription ||
                    StateDescription != null &&
                    StateDescription.Equals(other.StateDescription)
                ) && 
                (
                    Tags == other.Tags ||
                    Tags != null &&
                    Tags.SequenceEqual(other.Tags)
                ) && 
                (
                    UID == other.UID ||
                    UID != null &&
                    UID.Equals(other.UID)
                ) && 
                (
                    Advanced == other.Advanced ||
                    Advanced != null &&
                    Advanced.Equals(other.Advanced)
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
                    if (Parameters != null)
                    hashCode = hashCode * 59 + Parameters.GetHashCode();
                    if (ParameterGroups != null)
                    hashCode = hashCode * 59 + ParameterGroups.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                    if (Category != null)
                    hashCode = hashCode * 59 + Category.GetHashCode();
                    if (ItemType != null)
                    hashCode = hashCode * 59 + ItemType.GetHashCode();
                    if (Kind != null)
                    hashCode = hashCode * 59 + Kind.GetHashCode();
                    if (StateDescription != null)
                    hashCode = hashCode * 59 + StateDescription.GetHashCode();
                    if (Tags != null)
                    hashCode = hashCode * 59 + Tags.GetHashCode();
                    if (UID != null)
                    hashCode = hashCode * 59 + UID.GetHashCode();
                    if (Advanced != null)
                    hashCode = hashCode * 59 + Advanced.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ChannelTypeDTO left, ChannelTypeDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ChannelTypeDTO left, ChannelTypeDTO right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
