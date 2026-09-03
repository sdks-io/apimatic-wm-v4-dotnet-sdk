using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>getSelfShipAppointmentSlots</c> response.
/// </summary>
public record GetSelfShipAppointmentSlotsResponse
{
    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    /// <summary>
    /// The self ship appointment time slots availability and an expiration date for which the slots can be scheduled.
    /// </summary>
    [JsonPropertyName("selfShipAppointmentSlotsAvailability")]
    public required CommonSelfShipAppointmentSlotsAvailability SelfShipAppointmentSlotsAvailability { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
