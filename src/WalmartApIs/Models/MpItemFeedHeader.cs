using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.AnyOf;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
public record MpItemFeedHeader
{
    /// <summary>
    /// Business unit identifier matching the target market. For example, use WALMART_US for the US market.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("businessUnit")]
    public required string BusinessUnit { get; init; }

    /// <summary>
    /// ItemFeed subcategory for price update.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("subCategory")]
    public required string SubCategory { get; init; }

    /// <summary>
    /// The mart ID for the various markets are WALMART_CA for CA, WALMART_MEXICO for MX, and WALMART_CHILE for CL..&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("mart")]
    public required string Mart { get; init; }

    /// <summary>
    /// The type of feed for this request.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("feedType")]
    public required string FeedType { get; init; }

    /// <summary>
    /// The feed processing behavior. Use REPLACE to overwrite existing values.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("processMode")]
    public string? ProcessMode { get; init; }

    /// <summary>
    /// The market specific locale. Allowed values by market include: en for US, es for MX and CL, and en and fr for CA.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("locale")]
    public required Locale Locale { get; init; }

    /// <summary>
    /// The feed schema version. The values vary by region. 2.0.20240126-12_25_52-api for US, 5.0.20250801-18_47_55 for CA, MX and CL.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; }

    /// <summary>
    /// Origin of the data. Use External for partner submitted feeds.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("subset")]
    public required string Subset { get; init; }

    /// <summary>
    /// The tenant identifier for the marketplace. For example, use WALMART_CA for CA, WALMART_MEXICO for MX, and WALMART_CHILE for CL.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("tenant")]
    public required string Tenant { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
