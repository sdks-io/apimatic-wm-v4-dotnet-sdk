using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ListingQualityScorePayload
{
    /// <summary>
    /// Listing Quality
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("listingQuality")]
    public double? ListingQuality { get; init; }

    /// <summary>
    /// Score
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("score")]
    public Score? Score { get; init; }

    /// <summary>
    /// Post Purchase Quality
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("postPurchaseQuality")]
    public PostPurchaseQuality? PostPurchaseQuality { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
