using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The estimated shipping cost associated with the transportation option.
/// </summary>
public record CommonQuote
{
    /// <summary>
    /// The type and amount of currency.
    /// </summary>
    [JsonPropertyName("cost")]
    public required CommonCurrency Cost { get; init; }

    /// <summary>
    /// The time at which this transportation option quote expires. In ISO 8601 datetime with pattern <c>yyyy-MM-ddTHH:mm:ss.sssZ</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration")]
    public DateTimeOffset? Expiration { get; init; }

    /// <summary>
    /// Voidable until timestamp.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voidableUntil")]
    public DateTimeOffset? VoidableUntil { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
