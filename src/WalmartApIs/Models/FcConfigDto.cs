using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Comprises a list of all fulfillment center IDs along with their respective configurations.
/// </summary>
public record FcConfigDto
{
    /// <summary>
    /// List of Fulfillment Center Ids which are used as shipping nodes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipNodes")]
    [UniqueItems]
    public IReadOnlyList<string>? ShipNodes { get; init; }

    /// <summary>
    /// Flag denoting if the Fulfillment Center config settings are overriding account level settings
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isOverridden")]
    public bool? IsOverridden { get; init; }

    /// <summary>
    /// List of Fulfillment Center Ids which are used as shipping nodes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierConfigs")]
    [UniqueItems]
    public IReadOnlyList<CarrierConfigDto>? CarrierConfigs { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
