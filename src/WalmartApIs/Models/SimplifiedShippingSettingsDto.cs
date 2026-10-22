using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Simplified Shipping Settings
/// </summary>
public record SimplifiedShippingSettingsDto
{
    /// <summary>
    /// Account configuration to be set for a seller, comprising of Carrier configurations and Region configurations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("accountConfigs")]
    public SimplifiedAccountConfigForGetDto? AccountConfigs { get; init; }

    /// <summary>
    /// Comprises a list of all fulfillment center IDs along with their respective configurations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNodeConfigs")]
    [UniqueItems]
    public IReadOnlyList<FcConfigDto>? ShipNodeConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
