using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record PartnerFeedResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public IReadOnlyList<Error3>? Errors { get; init; }

    /// <summary>
    /// A unique ID used for tracking the Feed File.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedId")]
    public string? FeedId { get; init; }

    /// <summary>
    /// Can be one of the following: RECEIVED, INPROGRESS, PROCESSED, or ERROR
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("feedStatus")]
    public FeedStatus? FeedStatus { get; init; }

    /// <summary>
    /// List of errors for an item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ingestionErrors")]
    public IngestionErrors? IngestionErrors { get; init; }

    /// <summary>
    /// The number of items received. in the feed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsReceived")]
    public int? ItemsReceived { get; init; }

    /// <summary>
    /// The number of items in the feed that processed successfully.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsSucceeded")]
    public int? ItemsSucceeded { get; init; }

    /// <summary>
    /// The number of items in the feed that failed due to a data or system error.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsFailed")]
    public int? ItemsFailed { get; init; }

    /// <summary>
    /// The number of items in the feed that are still processing.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsProcessing")]
    public int? ItemsProcessing { get; init; }

    /// <summary>
    /// The object response to the starting number, where 0 is the first entity available for request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offset")]
    public int? Offset { get; init; }

    /// <summary>
    /// The number of items returned. Cannot be greater than 1000.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("limit")]
    public int? Limit { get; init; }

    /// <summary>
    /// List of ingestion status details for items in the feed.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemDetails")]
    public ItemDetails5? ItemDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
