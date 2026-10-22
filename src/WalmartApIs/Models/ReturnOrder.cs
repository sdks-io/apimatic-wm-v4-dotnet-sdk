using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// List of returns for the seller.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
public record ReturnOrder
{
    /// <summary>
    /// Return order identifier of the return order.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderId")]
    public string? ReturnOrderId { get; init; }

    /// <summary>
    /// Customer email address&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerEmailId")]
    public string? CustomerEmailId { get; init; }

    /// <summary>
    /// Customer information.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerName")]
    public CustomerName? CustomerName { get; init; }

    /// <summary>
    /// Customer sales order identifier. Use to filter results.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerOrderId")]
    public string? CustomerOrderId { get; init; }

    /// <summary>
    /// Date format for return order date.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderDate")]
    public DateTimeOffset? ReturnOrderDate { get; init; }

    /// <summary>
    /// Date format for return by order date.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnByDate")]
    public DateTimeOffset? ReturnByDate { get; init; }

    /// <summary>
    /// Determines when the refund was/will be issued to the customer.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refundMode")]
    public string? RefundMode { get; init; }

    /// <summary>
    /// Price of One unit of item, in this order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalRefundAmount")]
    public TotalRefundAmount? TotalRefundAmount { get; init; }

    /// <summary>
    /// These groups are created per label or type of carrier service required. (e.g., If order has some lines that can be clubbed and mailed together as a smart post then they belong to one return group. If a line is bulky and needs a different type of carrier service, then that line will be part of different group. Customer gets multiple labels depending on how many groups are created for the entire order.)&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnLineGroups")]
    public IReadOnlyList<ReturnLineGroup>? ReturnLineGroups { get; init; }

    /// <summary>
    /// A list of order lines in the return order.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderLines")]
    public IReadOnlyList<ReturnOrderLine>? ReturnOrderLines { get; init; }

    /// <summary>
    /// The shipments for return orders.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnOrderShipments")]
    public IReadOnlyList<ReturnOrderShipment>? ReturnOrderShipments { get; init; }

    /// <summary>
    /// The channel via order return got initiated.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnChannel")]
    public ReturnChannel? ReturnChannel { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
