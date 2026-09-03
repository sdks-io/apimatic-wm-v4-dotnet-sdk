using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record BulkInventoryItem
{
    [JsonPropertyName("sellerSku")]
    public required string SellerSku { get; init; }

    /// <summary>
    /// Declared on-hand quantity. Must be ≥ 0.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(0)]
    public required int Quantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillmentLag")]
    [Minimum(0)]
    [Maximum(14)]
    public int? FulfillmentLag { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
