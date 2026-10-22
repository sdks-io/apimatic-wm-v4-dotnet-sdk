using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Error response envelope for rate limit (429) errors returned by the API Gateway.
/// </summary>
public record ErrorResponse429Error
{
    /// <summary>
    /// List of rate limit error details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public IReadOnlyList<ErrorDetail429>? Error { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
