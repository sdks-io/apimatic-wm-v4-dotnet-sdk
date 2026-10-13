namespace WalmartApIs.Requests.Feeds;

/// <summary>
/// The inputs of the CancelFeed operation.
/// </summary>
public sealed record CancelFeedRequest
{
    public required string FeedId { get; init; }
}
