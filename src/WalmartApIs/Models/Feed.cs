using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Feed
{
    /// <summary>
    /// Unique identifier for this feed
    /// </summary>
    [JsonPropertyName("feedId")]
    public required string FeedId { get; init; }

    /// <summary>
    /// The type of feed submitted (e.g. LISTINGS_FEED, INVENTORY_FEED)
    /// </summary>
    [JsonPropertyName("feedType")]
    public required string FeedType { get; init; }

    /// <summary>
    /// Marketplace the feed was submitted to (e.g. WALMART_US)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; init; }

    /// <summary>
    /// Timestamp when the feed was received by the server
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Timestamp when feed processing began; absent until processing starts
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("processingStartedAt")]
    public DateTimeOffset? ProcessingStartedAt { get; init; }

    /// <summary>
    /// Timestamp when feed processing finished; absent until complete
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("processingCompletedAt")]
    public DateTimeOffset? ProcessingCompletedAt { get; init; }

    /// <summary>
    /// Current processing status of the feed
    /// </summary>
    [JsonPropertyName("processingStatus")]
    public required ProcessingStatus1 ProcessingStatus { get; init; }

    /// <summary>
    /// ID of the result document; present only when processingStatus is DONE. Use with GET /feeds/v4/feeds/{feedId}/document.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("resultFeedDocumentId")]
    public string? ResultFeedDocumentId { get; init; }

    /// <summary>
    /// Record-level processing counts; present only when processingStatus is DONE
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedProcessingSummary")]
    public FeedProcessingSummary? FeedProcessingSummary { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
