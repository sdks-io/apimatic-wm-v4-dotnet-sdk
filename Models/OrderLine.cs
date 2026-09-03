using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record OrderLine
{
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonPropertyName("sellerSku")]
    public required string SellerSku { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    [JsonPropertyName("quantity")]
    public required QuantityWithUnit Quantity { get; init; }

    [JsonPropertyName("itemPrice")]
    public required Money ItemPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lineStatus")]
    public LineStatus? LineStatus { get; init; }

    /// <summary>
    /// Walmart Ship Node identifier for WFS orders
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillmentOption")]
    public FulfillmentOption? FulfillmentOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
