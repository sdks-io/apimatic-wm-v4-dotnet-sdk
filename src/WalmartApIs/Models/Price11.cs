using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Applicable for CA, MX, and CL markets. Price details for the item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
/// </summary>
public record Price11
{
    /// <summary>
    /// The SKU of the item for which the price is being updated.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// The current selling price of the item on Walmart.com.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("price")]
    public required double Price { get; init; }

    /// <summary>
    /// The manufacturer's suggested retail price (MSRP) for the item.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("msrp")]
    public double? Msrp { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
