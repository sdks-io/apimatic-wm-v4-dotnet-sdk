using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The time range in which an item will likely be shipped once an order has been placed.
/// </summary>
public record DetailedShippingTimeType
{
    /// <summary>
    /// The minimum time, in hours, that the item will likely be shipped after the order has been placed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("minimumHours")]
    public long? MinimumHours { get; init; }

    /// <summary>
    /// The maximum time, in hours, that the item will likely be shipped after the order has been placed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("maximumHours")]
    public long? MaximumHours { get; init; }

    /// <summary>
    /// The date when the item will be available for shipping.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("availableDate")]
    public string? AvailableDate { get; init; }

    /// <summary>
    /// Indicates whether the item is available for shipping now, or on a known or an unknown date in the future.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("availabilityType")]
    public AvailabilityType? AvailabilityType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
