using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Seller accountable drivers, which impacting the seller response rate
/// </summary>
public record SellerAccountableSrrDrivers
{
    /// <summary>
    /// Seller response rate for miscellaneous customer enquires
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("miscellaneousRate")]
    public double? MiscellaneousRate { get; init; }

    /// <summary>
    /// Seller response rate for customer enquires regarding cancellations
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cancellationRate")]
    public double? CancellationRate { get; init; }

    /// <summary>
    /// Seller response rate for customer feedback
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedbackRate")]
    public double? FeedbackRate { get; init; }

    /// <summary>
    /// Seller response rate for customer enquires regarding item issues
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemIssueRate")]
    public double? ItemIssueRate { get; init; }

    /// <summary>
    /// Seller response rate for customer enquires regarding returns and refunds
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnsRefundsRate")]
    public double? ReturnsRefundsRate { get; init; }

    /// <summary>
    /// Seller response rate for customer enquires regarding order tracking
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackOrderRate")]
    public double? TrackOrderRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
