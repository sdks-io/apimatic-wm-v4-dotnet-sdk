using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ShipNodes2
{
    /// <summary>
    /// Last changes date for the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("modifiedDate")]
    public string? ModifiedDate { get; init; }

    /// <summary>
    /// The available quantity is the Quantity of an item that is available to be allocated to orders.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("availToSellQty")]
    public int? AvailToSellQty { get; init; }

    /// <summary>
    /// The on-hand balance is the quantity of active inventory stored at the warehouse.Active inventory is defined as the usable amount of an item that is in the warehouse.Inventory is active if it is not damaged, expired or being inspected.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("onHandQty")]
    public int? OnHandQty { get; init; }

    /// <summary>
    /// Identifies fulfillment aspect of inventory. Walmart, seller or 3PL fulfilled. Possible value is 'WFSFulfilled'. In later phase we will also add seller fulfilled inventory.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNodeType")]
    public string? ShipNodeType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
