using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Package Dimensions
/// </summary>
public record PackageDimension
{
    /// <summary>
    /// Package Type. Supported Package Types are -  'CUSTOM_PACKAGE', 'FEDEX_ENVELOPE', 'FEDEX_PAK'&lt;br/&gt;&lt;b&gt;Applicable to SWW and WPS.&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("packageType")]
    public required string PackageType { get; init; }

    /// <summary>
    /// Box Dimensions
    /// </summary>
    [JsonPropertyName("boxDimensions")]
    public required BoxDimensions4 BoxDimensions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
