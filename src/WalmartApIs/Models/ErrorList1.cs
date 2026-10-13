using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ErrorList1
{
    /// <summary>
    /// One or more errors describing why the request failed
    /// </summary>
    [JsonPropertyName("errors")]
    public required IReadOnlyList<Error3> Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
