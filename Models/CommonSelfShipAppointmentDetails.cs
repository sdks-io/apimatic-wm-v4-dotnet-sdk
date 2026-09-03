using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Appointment details for carrier pickup or Ship Node appointments.
/// </summary>
public record CommonSelfShipAppointmentDetails
{
    /// <summary>
    /// Identifier for appointment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("appointmentId")]
    public double? AppointmentId { get; init; }

    /// <summary>
    /// An appointment slot time with start and end.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("appointmentSlotTime")]
    public CommonAppointmentSlotTime? AppointmentSlotTime { get; init; }

    /// <summary>
    /// Status of the appointment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("appointmentStatus")]
    [StringLength(1024, MinimumLength = 1)]
    public string? AppointmentStatus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
