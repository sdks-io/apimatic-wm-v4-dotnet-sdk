using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// An item.
/// </summary>
public record Product
{
    /// <summary>
    /// Specifies the identifiers used to uniquely identify an item.
    /// </summary>
    [JsonPropertyName("Identifiers")]
    public required IdentifierType1 Identifiers { get; init; }

    /// <summary>
    /// A list of product attributes if applicable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("AttributeSets")]
    public IReadOnlyList<object>? AttributeSets { get; init; }

    /// <summary>
    /// A list that contains product variation information, if applicable.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Relationships")]
    public IReadOnlyList<object>? Relationships { get; init; }

    /// <summary>
    /// Competitive pricing information for the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("CompetitivePricing")]
    public CompetitivePricingType? CompetitivePricing { get; init; }

    /// <summary>
    /// A list of sales rank information for the item, by category.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SalesRankings")]
    public IReadOnlyList<SalesRankType>? SalesRankings { get; init; }

    /// <summary>
    /// A list of offers.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Offers")]
    public IReadOnlyList<OfferType1>? Offers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
