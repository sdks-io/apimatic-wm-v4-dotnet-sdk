using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Fee estimate parameters for a single item. Used in both single-item
/// and batch endpoints. Mirrors SP-API FeesEstimateRequest.
/// </summary>
public record FeesEstimateRequest
{
    /// <summary>
    /// Marketplace identifier.
    /// </summary>
    [JsonPropertyName("MarketplaceId")]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// true if fulfilled by Walmart Fulfillment Services (WFS); false for seller-fulfilled.
    /// </summary>
    [JsonPropertyName("IsWalmartFulfilled")]
    public required bool IsWalmartFulfilled { get; init; }

    /// <summary>
    /// Price information used to estimate fees.
    /// </summary>
    [JsonPropertyName("PriceToEstimateFees")]
    public required PriceToEstimateFees PriceToEstimateFees { get; init; }

    /// <summary>
    /// A caller-supplied identifier echoed back in the response for correlation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Identifier")]
    public string? Identifier { get; init; }

    /// <summary>
    /// Optional fulfillment program override for WFS items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("OptionalFulfillmentProgram")]
    public OptionalFulfillmentProgram? OptionalFulfillmentProgram { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
