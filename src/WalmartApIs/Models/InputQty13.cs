using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Indicates the quantity that has been ordered by the customers but not yet shipped.
/// <para>
/// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
/// </para>
/// </summary>
public record InputQty13
{
    /// <summary>
    /// Indicates a unit of measure. Walmart Marketplace supports only EACH, which indicates one individual sellable item.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("unit")]
    public string Unit { get; } = "EACH";

    /// <summary>
    /// Inventory Count.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("amount")]
    public required double Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
