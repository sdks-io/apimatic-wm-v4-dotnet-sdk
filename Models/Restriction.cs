using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Restriction
{
    [JsonPropertyName("marketplaceId")]
    public required string MarketplaceId { get; init; }

    [JsonPropertyName("conditionType")]
    public required string ConditionType { get; init; }

    /// <summary>
    /// Empty array means listing is not restricted
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reasons")]
    public IReadOnlyList<Reason>? Reasons { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
