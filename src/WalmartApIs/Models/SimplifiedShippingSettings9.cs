using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Simplified Shipping Settings.
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
/// </summary>
public record SimplifiedShippingSettings9
{
    /// <summary>
    /// Account configuration to be set for a seller, comprising of Carrier configurations and Region configurations.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accountConfigs")]
    public AccountConfigs8? AccountConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
