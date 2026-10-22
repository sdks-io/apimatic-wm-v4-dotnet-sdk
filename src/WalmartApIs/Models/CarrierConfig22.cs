using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage..
/// </summary>
public record CarrierConfig22
{
    /// <summary>
    /// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("configurations")]
    [UniqueItems]
    public IReadOnlyList<Configuration18>? Configurations { get; init; }

    /// <summary>
    /// Defines the carrier configurations used for shipping, like carrier name and carrier service.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carriers")]
    [UniqueItems]
    public IReadOnlyList<Carrier19>? Carriers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
