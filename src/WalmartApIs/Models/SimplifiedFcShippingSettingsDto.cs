using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Simplified Shipping Settings
/// </summary>
public record SimplifiedFcShippingSettingsDto
{
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
