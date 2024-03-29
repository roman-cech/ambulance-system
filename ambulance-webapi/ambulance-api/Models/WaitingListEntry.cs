/*
 * Waiting List API
 *
 * Ambulance Waiting List managegement for Web In Cloud system
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: aa@bb.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace eu.incloud.ambulance.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class WaitingListEntry : IEquatable<WaitingListEntry>
    { 
        /// <summary>
        /// Unique id of the entry in this waiting list
        /// </summary>
        /// <value>Unique id of the entry in this waiting list</value>
        [Required]
        [DataMember(Name="id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of patient in waiting list
        /// </summary>
        /// <value>Name of patient in waiting list</value>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Unique identifier of the patient known to Web In Cloud system
        /// </summary>
        /// <value>Unique identifier of the patient known to Web In Cloud system</value>
        [Required]
        [DataMember(Name="patientId")]
        public string PatientId { get; set; }

        /// <summary>
        /// Timestamp since when the patient entered the waiting list
        /// </summary>
        /// <value>Timestamp since when the patient entered the waiting list</value>
        [Required]
        [DataMember(Name="since")]
        public DateTime? Since { get; set; }

        /// <summary>
        /// Estimated time of entering ambulance. Ignored on post.
        /// </summary>
        /// <value>Estimated time of entering ambulance. Ignored on post.</value>
        [DataMember(Name="estimated")]
        public DateTime? Estimated { get; set; }

        /// <summary>
        /// Estimated duration of ambulance visit. If not provided then it will be computed based on condition and ambulance settings
        /// </summary>
        /// <value>Estimated duration of ambulance visit. If not provided then it will be computed based on condition and ambulance settings</value>
        [Required]
        [DataMember(Name="estimatedDurationMinutes")]
        public int? EstimatedDurationMinutes { get; set; }

        /// <summary>
        /// Gets or Sets Condition
        /// </summary>
        [DataMember(Name="condition")]
        public Condition Condition { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WaitingListEntry {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PatientId: ").Append(PatientId).Append("\n");
            sb.Append("  Since: ").Append(Since).Append("\n");
            sb.Append("  Estimated: ").Append(Estimated).Append("\n");
            sb.Append("  EstimatedDurationMinutes: ").Append(EstimatedDurationMinutes).Append("\n");
            sb.Append("  Condition: ").Append(Condition).Append("\n");
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
            return obj.GetType() == GetType() && Equals((WaitingListEntry)obj);
        }

        /// <summary>
        /// Returns true if WaitingListEntry instances are equal
        /// </summary>
        /// <param name="other">Instance of WaitingListEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WaitingListEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    PatientId == other.PatientId ||
                    PatientId != null &&
                    PatientId.Equals(other.PatientId)
                ) && 
                (
                    Since == other.Since ||
                    Since != null &&
                    Since.Equals(other.Since)
                ) && 
                (
                    Estimated == other.Estimated ||
                    Estimated != null &&
                    Estimated.Equals(other.Estimated)
                ) && 
                (
                    EstimatedDurationMinutes == other.EstimatedDurationMinutes ||
                    EstimatedDurationMinutes != null &&
                    EstimatedDurationMinutes.Equals(other.EstimatedDurationMinutes)
                ) && 
                (
                    Condition == other.Condition ||
                    Condition != null &&
                    Condition.Equals(other.Condition)
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
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (PatientId != null)
                    hashCode = hashCode * 59 + PatientId.GetHashCode();
                    if (Since != null)
                    hashCode = hashCode * 59 + Since.GetHashCode();
                    if (Estimated != null)
                    hashCode = hashCode * 59 + Estimated.GetHashCode();
                    if (EstimatedDurationMinutes != null)
                    hashCode = hashCode * 59 + EstimatedDurationMinutes.GetHashCode();
                    if (Condition != null)
                    hashCode = hashCode * 59 + Condition.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(WaitingListEntry left, WaitingListEntry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WaitingListEntry left, WaitingListEntry right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
