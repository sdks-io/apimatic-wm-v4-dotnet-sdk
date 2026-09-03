using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Order
{
    /// <summary>
    /// Walmart-assigned Purchase Order ID
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public required string PurchaseOrderId { get; init; }

    /// <summary>
    /// Customer-facing order reference
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; init; }

    [JsonPropertyName("sellerId")]
    public required string SellerId { get; init; }

    [JsonPropertyName("orderStatus")]
    public required OrderStatus OrderStatus { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillmentType")]
    public FulfillmentType? FulfillmentType { get; init; }

    [JsonPropertyName("purchaseDate")]
    public required DateTimeOffset PurchaseDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lastUpdatedDate")]
    public DateTimeOffset? LastUpdatedDate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orderTotal")]
    public Money? OrderTotal { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingAddress")]
    public Address2? ShippingAddress { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("orderLines")]
    public IReadOnlyList<OrderLine>? OrderLines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
