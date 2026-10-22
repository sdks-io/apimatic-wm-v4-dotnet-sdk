using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record SemItemEligibilityRequest
{
    /// <summary>
    /// List of filters to apply when checking eligibility.
    /// </summary>
    [JsonPropertyName("filters")]
    public required IReadOnlyList<SemFilter> Filters { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
