using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains only a starting DateTime.
/// </summary>
public record CommonWindowInput
{
    /// <summary>
    /// The start date of the window. In ISO 8601 datetime format with minute precision.
    /// </summary>
    [JsonPropertyName("start")]
    public required DateTimeOffset Start { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
