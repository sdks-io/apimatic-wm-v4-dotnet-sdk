using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Inventory quantity breakdown for a SKU at a ship node.
/// </summary>
public record InventoryDetails
{
    /// <summary>
    /// Units currently available to sell at this ship node.
    /// Null if the upstream quantity is unavailable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillableQuantity")]
    [Minimum(0)]
    public int? FulfillableQuantity { get; init; }

    /// <summary>
    /// Total units physically at this ship node, including available,
    /// reserved, and unfulfillable units. Null if unavailable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("onHandQuantity")]
    [Minimum(0)]
    public int? OnHandQuantity { get; init; }

    /// <summary>
    /// Breakdown of reserved quantities.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reservedQuantity")]
    public ReservedQuantity? ReservedQuantity { get; init; }

    /// <summary>
    /// Units currently under investigation for discrepancies between expected
    /// and physical on-hand counts. Null if no units are under investigation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("researchingQuantity")]
    public ResearchingQuantity? ResearchingQuantity { get; init; }

    /// <summary>
    /// Units that cannot be fulfilled due to damage, defects, or expiry.
    /// Null if no unfulfillable units exist.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unfulfillableQuantity")]
    public UnfulfillableQuantity? UnfulfillableQuantity { get; init; }

    /// <summary>
    /// Units for which a shipment has been created but not yet shipped.
    /// Null if no data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inboundWorkingQuantity")]
    [Minimum(0)]
    public int? InboundWorkingQuantity { get; init; }

    /// <summary>
    /// Units that have been shipped to the fulfillment center but not yet received.
    /// Null if no data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inboundShippedQuantity")]
    [Minimum(0)]
    public int? InboundShippedQuantity { get; init; }

    /// <summary>
    /// Units that are being received at the fulfillment center.
    /// Null if no data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inboundReceivingQuantity")]
    [Minimum(0)]
    public int? InboundReceivingQuantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
