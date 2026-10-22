using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Response payload containing the list of shipping cost estimates for available services.
/// </summary>
public record Data6
{
    /// <summary>
    /// List of estimates.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("estimates")]
    public IReadOnlyList<Estimate>? Estimates { get; init; }

    /// <summary>
    /// Alert message displayed when there are issues fetching estimates for the carrier service type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("alertMessage")]
    public string? AlertMessage { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
