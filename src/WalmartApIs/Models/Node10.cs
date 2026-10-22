using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Node10
{
    /// <summary>
    /// Specifies the unique identifier of the ship node for which the inventory is requested.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("shipNode")]
    public required string ShipNode { get; init; }

    /// <summary>
    /// Indicates the quantity that has been ordered by the customers but not yet shipped.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("inputQty")]
    public required InputQty13 InputQty { get; init; }

    /// <summary>
    /// Specifies the date when the inventory will be available at a ship node. The date format is YYYY-MM-DD.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: US only&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("inventoryAvailableDate")]
    public string? InventoryAvailableDate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
