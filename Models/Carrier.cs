using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Carrier
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>
    /// Carrier display name. Walmart-specific enum-widening for
    /// internally-fulfilled carriers (e.g. WALMART_GROUND) is
    /// captured by leaving this as a free string rather than a
    /// closed enum.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
