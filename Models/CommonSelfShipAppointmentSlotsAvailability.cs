using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The self ship appointment time slots availability and an expiration date for which the slots can be scheduled.
/// </summary>
public record CommonSelfShipAppointmentSlotsAvailability
{
    /// <summary>
    /// The time at which the self ship appointment slot expires. In ISO 8601 datetime format.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiresAt")]
    public DateTimeOffset? ExpiresAt { get; init; }

    /// <summary>
    /// A list of appointment slots.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("slots")]
    public IReadOnlyList<CommonAppointmentSlot>? Slots { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
