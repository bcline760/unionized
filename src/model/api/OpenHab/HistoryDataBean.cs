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
    public partial class HistoryDataBean : IEquatable<HistoryDataBean>
    { 
        /// <summary>
        /// Gets or Sets Time
        /// </summary>
        [DataMember(Name="time")]
        public long? Time { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state")]
        public string State { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HistoryDataBean {\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
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
            return obj.GetType() == GetType() && Equals((HistoryDataBean)obj);
        }

        /// <summary>
        /// Returns true if HistoryDataBean instances are equal
        /// </summary>
        /// <param name="other">Instance of HistoryDataBean to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HistoryDataBean other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Time == other.Time ||
                    Time != null &&
                    Time.Equals(other.Time)
                ) && 
                (
                    State == other.State ||
                    State != null &&
                    State.Equals(other.State)
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
                    if (Time != null)
                    hashCode = hashCode * 59 + Time.GetHashCode();
                    if (State != null)
                    hashCode = hashCode * 59 + State.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(HistoryDataBean left, HistoryDataBean right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HistoryDataBean left, HistoryDataBean right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}