using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>generateSelfShipAppointmentSlots</c> request.
/// </summary>
public record GenerateSelfShipAppointmentSlotsRequest
{
    /// <summary>
    /// The desired end date. In ISO 8601 datetime format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("desiredEndDate")]
    public DateTimeOffset? DesiredEndDate { get; init; }

    /// <summary>
    /// The desired start date. In ISO 8601 datetime format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("desiredStartDate")]
    public DateTimeOffset? DesiredStartDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
