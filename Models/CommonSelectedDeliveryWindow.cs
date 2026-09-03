using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Selected delivery window attributes.
/// </summary>
public record CommonSelectedDeliveryWindow
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
    /// The timestamp at which this window can no longer be edited.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("editableUntil")]
    public DateTimeOffset? EditableUntil { get; init; }

    /// <summary>
    /// The end timestamp of the window.
    /// </summary>
    [JsonPropertyName("endDate")]
    public required DateTimeOffset EndDate { get; init; }

    /// <summary>
    /// The start timestamp of the window.
    /// </summary>
    [JsonPropertyName("startDate")]
    public required DateTimeOffset StartDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
