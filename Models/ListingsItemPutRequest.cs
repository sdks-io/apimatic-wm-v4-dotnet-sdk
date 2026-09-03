using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record ListingsItemPutRequest
{
    /// <summary>
    /// Walmart product type for the listing
    /// </summary>
    [JsonPropertyName("productType")]
    public required string ProductType { get; init; }

    [JsonPropertyName("requirements")]
    public Requirements? Requirements { get; init; } = Requirements.Listing;

    /// <summary>
    /// JSON object of product attributes matching the product type definition schema
    /// </summary>
    [JsonPropertyName("attributes")]
    public required object Attributes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
