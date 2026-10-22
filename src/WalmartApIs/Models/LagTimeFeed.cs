using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record LagTimeFeed
{
    [JsonPropertyName("lagTimeHeader")]
    public required LagTimeHeader LagTimeHeader { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lagTime")]
    public IReadOnlyList<LagTime1>? LagTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
