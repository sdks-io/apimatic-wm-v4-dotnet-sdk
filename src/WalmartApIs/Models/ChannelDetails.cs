using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record ChannelDetails
{
    /// <summary>
    /// Sales-channel hint that lets shipping-v4 route differently for
    /// WFS-fulfilled orders, marketplace-seller-fulfilled orders, and
    /// external (off-Walmart) orders.
    /// </summary>
    [JsonPropertyName("channelType")]
    public required ChannelType ChannelType { get; init; }

    /// <summary>
    /// Marketplace-side order context for orders originating on the
    /// Walmart Marketplace surface. Equivalent in shape to industry
    /// SP-API's order-details block; renamed to be vendor-neutral.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceOrderDetails")]
    public MarketplaceOrderDetails? MarketplaceOrderDetails { get; init; }

    /// <summary>
    /// Marketplace-side shipment context. Renamed from the industry
    /// SP-API "vendor-shipment-details" block to be vendor-neutral.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceShipmentDetails")]
    public MarketplaceShipmentDetails? MarketplaceShipmentDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
