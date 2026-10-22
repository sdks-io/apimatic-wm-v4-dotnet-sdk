using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage..
/// </summary>
public record AutomatedShippingSettingsConfigurationDto
{
    /// <summary>
    /// Region configurations to which shipping has to be covered with added carriers.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("regions")]
    [UniqueItems]
    public IReadOnlyList<RegionDto>? Regions { get; init; }

    /// <summary>
    /// Type of address to which shipping has to be covered as part of mentioned region, sub region and states.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("addressTypes")]
    [UniqueItems]
    public IReadOnlyList<AddressType>? AddressTypes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
