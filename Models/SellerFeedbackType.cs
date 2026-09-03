using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information about the seller's feedback, including the percentage of positive feedback and total ratings.
/// </summary>
public record SellerFeedbackType
{
    /// <summary>
    /// The percentage of positive feedback for the seller in the past 365 days.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerPositiveFeedbackRating")]
    public double? SellerPositiveFeedbackRating { get; init; }

    /// <summary>
    /// The number of ratings received about the seller.
    /// </summary>
    [JsonPropertyName("FeedbackCount")]
    public required long FeedbackCount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
