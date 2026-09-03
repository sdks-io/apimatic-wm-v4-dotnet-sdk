using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information pertaining to a delivery window option.
/// </summary>
public record CommonDeliveryWindowOption
{
    /// <summary>
    /// The type of delivery window availability. Values: <c>AVAILABLE</c>, <c>BLOCKED</c>, <c>CONGESTED</c>, <c>DISCOUNTED</c>.
    /// </summary>
    [JsonPropertyName("availabilityType")]
    public required string AvailabilityType { get; init; }

    /// <summary>
    /// Identifier of a delivery window option.
    /// </summary>
    [JsonPropertyName("deliveryWindowOptionId")]
    [StringLength(38, MinimumLength = 36)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string DeliveryWindowOptionId { get; init; }

    /// <summary>
    /// The time at which this delivery window option ends. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mmZ</c>.
    /// </summary>
    [JsonPropertyName("endDate")]
    public required DateTimeOffset EndDate { get; init; }

    /// <summary>
    /// The time at which this delivery window option starts. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mmZ</c>.
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTimeOffset StartDate { get; init; }

    /// <summary>
    /// The time at which this delivery window option is no longer valid. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mmZ</c>.
    /// </summary>
    [JsonPropertyName("validUntil")]
    public required DateTimeOffset ValidUntil { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
