using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record FulfillmentOrder
{
    /// <summary>
    /// Seller-defined order ID
    /// </summary>
    [JsonPropertyName("sellerFulfillmentOrderId")]
    public required string SellerFulfillmentOrderId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; init; }

    /// <summary>
    /// Order ID shown to the recipient
    /// </summary>
    [JsonPropertyName("displayableOrderId")]
    public required string DisplayableOrderId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("displayableOrderDate")]
    public DateTimeOffset? DisplayableOrderDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("displayableOrderComment")]
    public string? DisplayableOrderComment { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingSpeedCategory")]
    public ShippingSpeedCategory? ShippingSpeedCategory { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("destinationAddress")]
    public Address? DestinationAddress { get; init; }

    [JsonPropertyName("fulfillmentOrderStatus")]
    public required FulfillmentOrderStatus FulfillmentOrderStatus { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("statusUpdatedAt")]
    public DateTimeOffset? StatusUpdatedAt { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("notificationEmails")]
    public IReadOnlyList<string>? NotificationEmails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
