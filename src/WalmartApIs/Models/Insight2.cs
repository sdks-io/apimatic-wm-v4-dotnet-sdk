using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Insight2
{
    /// <summary>
    /// High-level issue type explaining why your item is unpublished.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unpublishedIssueType")]
    public string? UnpublishedIssueType { get; init; }

    /// <summary>
    /// Based on your current inventory level, this is the estimated per-unit storage cost of your unpublished WFS items for the next 30 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("estimatedStorageFee")]
    public double? EstimatedStorageFee { get; init; }

    /// <summary>
    /// The estimated dollar value of the available inventory for each unpublished WFS item in your catalog.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryValue")]
    public double? InventoryValue { get; init; }

    /// <summary>
    /// Indicates whether the item is identified as a customer favorite based on customer demand.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerFavorite")]
    public bool? CustomerFavorite { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
