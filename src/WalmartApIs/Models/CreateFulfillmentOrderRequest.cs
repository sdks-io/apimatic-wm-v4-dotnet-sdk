using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record CreateFulfillmentOrderRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; init; }

    [JsonPropertyName("sellerFulfillmentOrderId")]
    [MaxLength(40)]
    public required string SellerFulfillmentOrderId { get; init; }

    [JsonPropertyName("displayableOrderId")]
    [MaxLength(40)]
    public required string DisplayableOrderId { get; init; }

    [JsonPropertyName("displayableOrderDate")]
    public required DateTimeOffset DisplayableOrderDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("displayableOrderComment")]
    [MaxLength(1000)]
    public string? DisplayableOrderComment { get; init; }

    [JsonPropertyName("shippingSpeedCategory")]
    public required ShippingSpeedCategory ShippingSpeedCategory { get; init; }

    [JsonPropertyName("destinationAddress")]
    public required Address DestinationAddress { get; init; }

    [JsonPropertyName("items")]
    public required IReadOnlyList<CreateFulfillmentOrderItem> Items { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("notificationEmails")]
    public IReadOnlyList<string>? NotificationEmails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
