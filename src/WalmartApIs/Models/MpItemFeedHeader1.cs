using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.AnyOf;

namespace WalmartApIs.Models;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
/// </summary>
public record MpItemFeedHeader1
{
    /// <summary>
    /// The mart ID for the various markets are WALMART_CA for CA, WALMART_MEXICO for MX, and WALMART_CHILE for CL..&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("mart")]
    public required string Mart { get; init; }

    /// <summary>
    /// The market specific locale. Allowed values by market include: es for MX and CL, and en and fr for CA.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("locale")]
    public required Locale1 Locale { get; init; }

    /// <summary>
    /// The feed schema version. The values is 5.0.20250801-18_47_55-api for CA, MX and CL.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; init; }

    /// <summary>
    /// Business unit identifier matching the target market. For example WALMART_CA for CA, WALMART_MEXICO for MX, WALMART_CHILE for CL.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("businessUnit")]
    public required string BusinessUnit { get; init; }

    /// <summary>
    /// The tenant identifier for the marketplace. For example, use WALMART_CA for CA, WALMART_MEXICO for MX, WALMART_CHILE for CL.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("tenant")]
    public required string Tenant { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
