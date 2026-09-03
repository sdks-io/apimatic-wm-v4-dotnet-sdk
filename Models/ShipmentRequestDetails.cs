using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ShipmentRequestDetails
{
    /// <summary>
    /// Walmart Purchase Order ID
    /// </summary>
    [JsonPropertyName("purchaseOrderId")]
    public required string PurchaseOrderId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sellerOrderId")]
    public string? SellerOrderId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemList")]
    public IReadOnlyList<Item2>? ItemList { get; init; }

    [JsonPropertyName("shipFromAddress")]
    public required Address1 ShipFromAddress { get; init; }

    [JsonPropertyName("shipToAddress")]
    public required Address1 ShipToAddress { get; init; }

    [JsonPropertyName("packageDimensions")]
    public required PackageDimensions PackageDimensions { get; init; }

    [JsonPropertyName("weight")]
    public required Weight Weight { get; init; }

    [JsonPropertyName("shipDate")]
    public required DateTimeOffset ShipDate { get; init; }

    [JsonPropertyName("shippingServiceOptions")]
    public required ShippingServiceOptions ShippingServiceOptions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
