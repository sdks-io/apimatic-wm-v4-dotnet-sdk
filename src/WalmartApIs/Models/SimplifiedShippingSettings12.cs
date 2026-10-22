using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Simplified Shipping Settings.
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
/// </summary>
public record SimplifiedShippingSettings12
{
    /// <summary>
    /// Account configuration to be set for a seller, comprising of Carrier configurations and Region configurations.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accountConfigs")]
    public AccountConfigs11? AccountConfigs { get; init; }

    /// <summary>
    /// Comprises a list of all fulfillment center IDs along with their respective configurations.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNodeConfigs")]
    [UniqueItems]
    public IReadOnlyList<ShipNodeConfig6>? ShipNodeConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
