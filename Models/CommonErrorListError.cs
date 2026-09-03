using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A list of error responses returned when a request is unsuccessful.
/// </summary>
public record CommonErrorListError
{
    /// <summary>
    /// List of errors.
    /// </summary>
    [JsonPropertyName("errors")]
    public required IReadOnlyList<CommonError> Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
