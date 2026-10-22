using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information about the individual feed.
/// </summary>
public record Feed5
{
    /// <summary>
    /// A unique ID used for tracking the Feed File.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedId")]
    public string? FeedId { get; init; }

    /// <summary>
    /// The source of the feed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedSource")]
    public string? FeedSource { get; init; }

    /// <summary>
    /// Specifies the feed type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedType")]
    public string? FeedType { get; init; }

    /// <summary>
    /// Indicates the seller ID.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; init; }

    /// <summary>
    /// The number of items received.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsReceived")]
    public long? ItemsReceived { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsSucceeded")]
    public long? ItemsSucceeded { get; init; }

    /// <summary>
    /// The number of items in the feed that failed due to a data or system error.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsFailed")]
    public long? ItemsFailed { get; init; }

    /// <summary>
    /// The number of items in the feed that are still in progress.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsProcessing")]
    public long? ItemsProcessing { get; init; }

    /// <summary>
    /// Can be one of the following: RECEIVED, INPROGRESS, PROCESSED, or ERROR. For details, see the definitions listed under 'Feed Statuses' at the beginning of this section.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedStatus")]
    public string? FeedStatus { get; init; }

    /// <summary>
    /// The date and time the feed was submitted. Format: yyyymmddThh:mm:ss.xxxz
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedDate")]
    public long? FeedDate { get; init; }

    /// <summary>
    /// The batch ID for the feed, if provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("batchId")]
    public string? BatchId { get; init; }

    /// <summary>
    /// The most recent time the feed was modified. Format: yyyymmddThh:mm:ss.xxxz
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("modifiedDtm")]
    public long? ModifiedDtm { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
