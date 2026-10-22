using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A list of order lines in the return order.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
public record ReturnOrderLine
{
    /// <summary>
    /// The returns order line number for that return.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderLineNumber")]
    public int? ReturnOrderLineNumber { get; init; }

    /// <summary>
    /// The purchase order line number for the return created.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("primeLineNumber")]
    public string? PrimeLineNumber { get; init; }

    /// <summary>
    /// The sales order line number for the return created.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salesOrderLineNumber")]
    public int? SalesOrderLineNumber { get; init; }

    /// <summary>
    /// Gives the reason that was selected during the return creation.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnReason")]
    public string? ReturnReason { get; init; }

    /// <summary>
    /// Gives the return reason code associated with returnReason.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reasonCode")]
    public string? ReasonCode { get; init; }

    /// <summary>
    /// Gives the returnDescription for the return created. It would be empty if returnDescription is 'Fraud'.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnDescription")]
    public string? ReturnDescription { get; init; }

    /// <summary>
    /// The purchase order ID for the return created.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purchaseOrderId")]
    public string? PurchaseOrderId { get; init; }

    /// <summary>
    /// The purchase order line number for the return created.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("purchaseOrderLineNumber")]
    public int? PurchaseOrderLineNumber { get; init; }

    /// <summary>
    /// &lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isReturnForException")]
    public bool? IsReturnForException { get; init; }

    /// <summary>
    /// An arbitrary alphanumeric unique ID, specified by the seller, which identifies each item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("item")]
    public Item2? Item { get; init; }

    /// <summary>
    /// Information relating to the charge for the orderLine.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("charges")]
    public IReadOnlyList<Charge>? Charges { get; init; }

    /// <summary>
    /// Current status of return. (e.g., 'INITIATED') &lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX | CA |CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>
    /// Refund amount details for the return order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refundAmount")]
    public Gmv? RefundAmount { get; init; }

    /// <summary>
    /// Determines Walmart Fulfilled vs Seller Fulfilled returns.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX | CA | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isWFSEnabled")]
    public string? IsWfsEnabled { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
