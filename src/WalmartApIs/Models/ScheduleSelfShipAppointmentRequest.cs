using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>scheduleSelfShipAppointment</c> request.
/// </summary>
public record ScheduleSelfShipAppointmentRequest
{
    /// <summary>
    /// Reason for cancelling or rescheduling a self-ship appointment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reasonComment")]
    public CommonReasonComment? ReasonComment { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
