using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Standardized error response envelope containing an array of error details.
/// All error responses from the API follow this structure.
/// </summary>
public record ErrorResponseError
{
    /// <summary>
    /// List of error details. Typically contains a single error,
    /// but may contain multiple errors for validation failures.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public IReadOnlyList<ErrorDetail>? Error { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
