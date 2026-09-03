using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record GetFulfillmentPreviewItem
{
    [JsonPropertyName("sellerSku")]
    public required string SellerSku { get; init; }

    [JsonPropertyName("quantity")]
    [Minimum(1)]
    public required int Quantity { get; init; }

    [JsonPropertyName("sellerFulfillmentOrderItemId")]
    public required string SellerFulfillmentOrderItemId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
