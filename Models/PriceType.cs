using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Item price information. LandedPrice = ListingPrice + Shipping. Walmart does not have a seller-configurable per-offer loyalty points mechanism; the Points field from the SP-API reference spec is omitted..
/// </summary>
public record PriceType
{
    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("LandedPrice")]
    public MoneyType? LandedPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonPropertyName("ListingPrice")]
    public required MoneyType ListingPrice { get; init; }

    /// <summary>
    /// Currency type and monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Shipping")]
    public MoneyType? Shipping { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
