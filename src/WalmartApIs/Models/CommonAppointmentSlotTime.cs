using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// An appointment slot time with start and end., Contains details for a transportation carrier appointment., An appointment slot time with start and end., Contains details for a transportation carrier appointment.
/// </summary>
public record CommonAppointmentSlotTime
{
    /// <summary>
    /// The end timestamp of the appointment in UTC.
    /// </summary>
    [JsonPropertyName("endTime")]
    public required DateTimeOffset EndTime { get; init; }

    /// <summary>
    /// The start timestamp of the appointment in UTC.
    /// </summary>
    [JsonPropertyName("startTime")]
    public required DateTimeOffset StartTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
