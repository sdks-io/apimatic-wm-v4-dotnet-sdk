using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record UpdateInventoryRequest
{
    /// <summary>
    /// Declared on-hand quantity (maps to PIS inputQty). Must be ≥ 0.
    /// </summary>
    [JsonPropertyName("quantity")]
    [Minimum(0)]
    public required int Quantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; init; }

    /// <summary>
    /// Lead time in days to ship (0-4 for standard)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillmentLag")]
    [Minimum(0)]
    [Maximum(14)]
    public int? FulfillmentLag { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
