using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// boxItems - A list of items that the seller will be shipping in this package. Each item must correspond to a line item in the specified purchaseOrder. The lineId and SKU fields are used to uniquely identify the specific item being shipped.
/// </summary>
public record BoxItem10
{
    /// <summary>
    /// sku of an item
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Quantity of Item
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// PO Line Number
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
