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
    public partial class EnrichedItemDTO : IEquatable<EnrichedItemDTO>
    { 
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name")]
        public string Name { get; set; }

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
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name="tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or Sets GroupNames
        /// </summary>
        [DataMember(Name="groupNames")]
        public List<string> GroupNames { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [DataMember(Name="link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets TransformedState
        /// </summary>
        [DataMember(Name="transformedState")]
        public string TransformedState { get; set; }

        /// <summary>
        /// Gets or Sets StateDescription
        /// </summary>
        [DataMember(Name="stateDescription")]
        public StateDescription StateDescription { get; set; }

        /// <summary>
        /// Gets or Sets Metadata
        /// </summary>
        [DataMember(Name="metadata")]
        public Dictionary<string, Object> Metadata { get; set; }

        /// <summary>
        /// Gets or Sets Editable
        /// </summary>
        [DataMember(Name="editable")]
        public bool? Editable { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EnrichedItemDTO {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  GroupNames: ").Append(GroupNames).Append("\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  TransformedState: ").Append(TransformedState).Append("\n");
            sb.Append("  StateDescription: ").Append(StateDescription).Append("\n");
            sb.Append("  Metadata: ").Append(Metadata).Append("\n");
            sb.Append("  Editable: ").Append(Editable).Append("\n");
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
            return obj.GetType() == GetType() && Equals((EnrichedItemDTO)obj);
        }

        /// <summary>
        /// Returns true if EnrichedItemDTO instances are equal
        /// </summary>
        /// <param name="other">Instance of EnrichedItemDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnrichedItemDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
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
                    Tags == other.Tags ||
                    Tags != null &&
                    Tags.SequenceEqual(other.Tags)
                ) && 
                (
                    GroupNames == other.GroupNames ||
                    GroupNames != null &&
                    GroupNames.SequenceEqual(other.GroupNames)
                ) && 
                (
                    Link == other.Link ||
                    Link != null &&
                    Link.Equals(other.Link)
                ) && 
                (
                    State == other.State ||
                    State != null &&
                    State.Equals(other.State)
                ) && 
                (
                    TransformedState == other.TransformedState ||
                    TransformedState != null &&
                    TransformedState.Equals(other.TransformedState)
                ) && 
                (
                    StateDescription == other.StateDescription ||
                    StateDescription != null &&
                    StateDescription.Equals(other.StateDescription)
                ) && 
                (
                    Metadata == other.Metadata ||
                    Metadata != null &&
                    Metadata.SequenceEqual(other.Metadata)
                ) && 
                (
                    Editable == other.Editable ||
                    Editable != null &&
                    Editable.Equals(other.Editable)
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
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Label != null)
                    hashCode = hashCode * 59 + Label.GetHashCode();
                    if (Category != null)
                    hashCode = hashCode * 59 + Category.GetHashCode();
                    if (Tags != null)
                    hashCode = hashCode * 59 + Tags.GetHashCode();
                    if (GroupNames != null)
                    hashCode = hashCode * 59 + GroupNames.GetHashCode();
                    if (Link != null)
                    hashCode = hashCode * 59 + Link.GetHashCode();
                    if (State != null)
                    hashCode = hashCode * 59 + State.GetHashCode();
                    if (TransformedState != null)
                    hashCode = hashCode * 59 + TransformedState.GetHashCode();
                    if (StateDescription != null)
                    hashCode = hashCode * 59 + StateDescription.GetHashCode();
                    if (Metadata != null)
                    hashCode = hashCode * 59 + Metadata.GetHashCode();
                    if (Editable != null)
                    hashCode = hashCode * 59 + Editable.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(EnrichedItemDTO left, EnrichedItemDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EnrichedItemDTO left, EnrichedItemDTO right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
