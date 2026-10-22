using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record AdditionalAttributes1
{
    [JsonPropertyName("additionalAttribute")]
    public required IReadOnlyList<AdditionalAttribute> AdditionalAttribute { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
