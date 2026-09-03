using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Echoes back the item identifier and request parameters that produced
/// this result. Mirrors SP-API FeesEstimateIdentifier.
/// </summary>
public record FeesEstimateIdentifier
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("MarketplaceId")]
    public string? MarketplaceId { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("IdType")]
    public IdType1? IdType { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("IdValue")]
    public string? IdValue { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("IsWalmartFulfilled")]
    public bool? IsWalmartFulfilled { get; init; }

    /// <summary>
    /// Price information used to estimate fees.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("PriceToEstimateFees")]
    public PriceToEstimateFees? PriceToEstimateFees { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerId")]
    public string? SellerId { get; init; }

    /// <summary>
    /// Echoed from the request Identifier field.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerInputIdentifier")]
    public string? SellerInputIdentifier { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("OptionalFulfillmentProgram")]
    public string? OptionalFulfillmentProgram { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
