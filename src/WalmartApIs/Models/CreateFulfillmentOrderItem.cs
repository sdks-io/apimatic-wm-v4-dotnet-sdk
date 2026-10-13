using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record CreateFulfillmentOrderItem
{
    [JsonPropertyName("sellerSku")]
    public required string SellerSku { get; init; }

    [JsonPropertyName("sellerFulfillmentOrderItemId")]
    [MaxLength(50)]
    public required string SellerFulfillmentOrderItemId { get; init; }

    [JsonPropertyName("quantity")]
    [Minimum(1)]
    public required int Quantity { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("giftMessage")]
    [MaxLength(512)]
    public string? GiftMessage { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("displayableComment")]
    [MaxLength(250)]
    public string? DisplayableComment { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
