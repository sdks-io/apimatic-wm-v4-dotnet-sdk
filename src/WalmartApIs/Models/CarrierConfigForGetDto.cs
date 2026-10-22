using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Defines the carrier configurations used for shipping, like carrier details and their corresponding region coverage..
/// </summary>
public record CarrierConfigForGetDto
{
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
