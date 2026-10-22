using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Box Items
/// </summary>
public record BoxItem8
{
    /// <summary>
    /// sku of an item. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Quantity of Item. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// Country of origin (country code) of item.&lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: MX&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("countryOfOrigin")]
    public string? CountryOfOrigin { get; init; }

    /// <summary>
    /// primeLineNo from CA order's response. &lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
