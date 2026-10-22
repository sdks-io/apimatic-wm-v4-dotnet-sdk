using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3InventoryRequest
{
    /// <summary>
    /// A seller-provided Product ID. Response will have decoded value.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Quantity that has been ordered by the customers but not yet shipped.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("quantity")]
    public required Quantity5 Quantity { get; init; }

    /// <summary>
    /// Information about when the inventory is expected at the given ship node. Format:YYYY-MM-DD
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
