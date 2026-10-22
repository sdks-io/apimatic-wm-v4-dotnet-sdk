using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Claim details.
/// </summary>
public record Payload
{
    /// <summary>
    /// Marketplace purchase-order number associated with the item in this claim.
    /// </summary>
    [JsonPropertyName("purchaseOrderNo")]
    public required string PurchaseOrderNo { get; init; }

    /// <summary>
    /// Line number within the purchase order that maps to the claimed SKU.
    /// </summary>
    [JsonPropertyName("purchaseOrderLineNo")]
    public required string PurchaseOrderLineNo { get; init; }

    /// <summary>
    /// Customer sales-order number for the shipment.
    /// </summary>
    [JsonPropertyName("salesOrderNo")]
    public required string SalesOrderNo { get; init; }

    /// <summary>
    /// Line number within the sales order that maps to the claimed SKU.
    /// </summary>
    [JsonPropertyName("salesOrderLineNo")]
    public required string SalesOrderLineNo { get; init; }

    /// <summary>
    /// Identifier for the fulfiller’s line item in the warehouse/fulfillment center manifest.
    /// </summary>
    [JsonPropertyName("fulfillerLineId")]
    public required string FulfillerLineId { get; init; }

    /// <summary>
    /// Number of units being claimed for this line.
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// Return-order ID that triggered or is linked to the claim.
    /// </summary>
    [JsonPropertyName("returnOrderId")]
    public required string ReturnOrderId { get; init; }

    /// <summary>
    /// Claim category: LIT (lost in transit), LAD (lost after delivery), or DAMAGED.
    /// </summary>
    [JsonPropertyName("claimType")]
    public required ClaimType ClaimType { get; init; }

    /// <summary>
    /// Free-form claim notes from the seller.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("notes")]
    public string? Notes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
