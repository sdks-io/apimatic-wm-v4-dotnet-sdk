using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Sub region configurations to which shipping has to be covered with added carriers.
/// </summary>
public record SubRegionDto
{
    /// <summary>
    /// Sub region code for covered shipping.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subRegionCode")]
    public string? SubRegionCode { get; init; }

    /// <summary>
    /// Sub region name for covered shipping.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("subRegionName")]
    public string? SubRegionName { get; init; }

    /// <summary>
    /// State configuration to which shipping has to be covered with added carriers as part of mentioned sub region area.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("states")]
    [UniqueItems]
    public IReadOnlyList<StateDto>? States { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
