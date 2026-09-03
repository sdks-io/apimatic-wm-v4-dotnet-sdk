using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Item
{
    /// <summary>
    /// Walmart Product ID (WPID) — alphanumeric catalog identifier
    /// </summary>
    [JsonPropertyName("walmartItemId")]
    public required string WalmartItemId { get; init; }

    [JsonPropertyName("marketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// Key product attributes (name, brand, description, etc.)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("attributes")]
    public IReadOnlyDictionary<string, object>? Attributes { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("identifiers")]
    public ItemIdentifiers? Identifiers { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("images")]
    public IReadOnlyList<ItemImage>? Images { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productTypes")]
    public IReadOnlyList<ItemProductType>? ProductTypes { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("salesRanks")]
    public IReadOnlyList<SalesRank>? SalesRanks { get; init; }

    /// <summary>
    /// Variant relationships (e.g. color/size variants)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("relationships")]
    public IReadOnlyList<ItemRelationship>? Relationships { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
