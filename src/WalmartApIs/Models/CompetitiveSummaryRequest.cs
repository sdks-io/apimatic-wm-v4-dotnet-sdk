using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// An individual competitive summary request.
/// </summary>
public record CompetitiveSummaryRequest
{
    /// <summary>
    /// The Walmart Item ID of the item .
    /// </summary>
    [JsonPropertyName("walmartItemId")]
    public required string WalmartItemId { get; init; }

    /// <summary>
    /// A marketplace identifier.
    /// </summary>
    [JsonPropertyName("marketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// The list of requested competitive pricing data for the product.
    /// </summary>
    [JsonPropertyName("includedData")]
    public required IReadOnlyList<IncludedDatum2> IncludedData { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
