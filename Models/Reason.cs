using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Reason
{
    /// <summary>
    /// Localized human-readable message explaining the restriction
    /// </summary>
    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("reasonCode")]
    public required ReasonCode ReasonCode { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("links")]
    public IReadOnlyList<Link>? Links { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
