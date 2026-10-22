using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TotalInsight2
{
    /// <summary>
    /// The total number of units of all your unpublished items that are currently in stock at WFS fulfillment centers.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalUnpublishedUnitsStored")]
    public double? TotalUnpublishedUnitsStored { get; init; }

    /// <summary>
    /// Based on your current inventory level, this is the estimated total cost of storing your unpublished WFS items for the next 30 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalEstimatedStorageFee")]
    public double? TotalEstimatedStorageFee { get; init; }

    /// <summary>
    /// The estimated total dollar value of the available inventory for all your WFS unpublished items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalInventoryValue")]
    public double? TotalInventoryValue { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
