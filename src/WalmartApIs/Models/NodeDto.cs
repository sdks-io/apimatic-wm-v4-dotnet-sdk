using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record NodeDto
{
    /// <summary>
    /// ShipNode Id of the ship node for which the inventory is requested
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNode")]
    public string? ShipNode { get; init; }

    /// <summary>
    /// Quantity of an item that is input by the seller
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inputQty")]
    public InputQty? InputQty { get; init; }

    /// <summary>
    /// Quantity of an item that is available to be allocated to orders.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("availToSellQty")]
    public AvailToSellQty? AvailToSellQty { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public IReadOnlyList<Error4>? Errors { get; init; }

    /// <summary>
    /// Inventory available date for a ship node. Format:YYYY-MM-DD
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryAvailableDate")]
    public string? InventoryAvailableDate { get; init; }

    /// <summary>
    /// Quantity that has been ordered by the customers but not yet shipped.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reservedQty")]
    public SupplyQuantity? ReservedQty { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
