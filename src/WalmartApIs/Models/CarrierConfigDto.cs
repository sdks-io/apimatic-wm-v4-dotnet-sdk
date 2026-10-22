using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// List of Fulfillment Center Ids which are used as shipping nodes.
/// </summary>
public record CarrierConfigDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isDefault")]
    public bool? IsDefault { get; init; }

    /// <summary>
    /// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage..
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("configurations")]
    [UniqueItems]
    public IReadOnlyList<AutomatedShippingSettingsConfigurationDto>? Configurations { get; init; }

    /// <summary>
    /// Defines the carrier configurations used for shipping, like carrier name and carrier service.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carriers")]
    [UniqueItems]
    public IReadOnlyList<CarrierDto>? Carriers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
