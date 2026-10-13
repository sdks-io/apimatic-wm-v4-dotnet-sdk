using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>scheduleSelfShipAppointment</c> response.
/// </summary>
public record ScheduleSelfShipAppointmentResponse
{
    /// <summary>
    /// Appointment details for carrier pickup or Ship Node appointments.
    /// </summary>
    [JsonPropertyName("selfShipAppointmentDetails")]
    public required CommonSelfShipAppointmentDetails SelfShipAppointmentDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
