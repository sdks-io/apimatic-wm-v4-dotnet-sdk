using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Price information used to estimate fees.
/// </summary>
public record PriceToEstimateFees
{
    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonPropertyName("ListingPrice")]
    public required MoneyType1 ListingPrice { get; init; }

    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Shipping")]
    public MoneyType1? Shipping { get; init; }

    /// <summary>
    /// Walmart Rewards points.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Points")]
    public Points1? Points { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
