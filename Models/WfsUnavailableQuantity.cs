using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record WfsUnavailableQuantity
{
    /// <summary>
    /// Units held pending inventory review
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryReviewUnits")]
    [Minimum(0)]
    public int? InventoryReviewUnits { get; init; }

    /// <summary>
    /// Units held during fulfillment center movement
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryMovementUnits")]
    [Minimum(0)]
    public int? InventoryMovementUnits { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
