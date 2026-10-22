using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Simplified Shipping Settings
/// </summary>
public record SimplifiedAccountShippingSettingsForUpdateDto
{
    /// <summary>
    /// Account configuration to be set for a seller, comprising of Carrier configurations and Region configurations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accountConfigs")]
    public SimplifiedAccountConfigForUpdateDto? AccountConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
