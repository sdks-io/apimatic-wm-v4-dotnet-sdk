namespace WalmartApIs.Requests.Feeds;

/// <summary>
/// The inputs of the GetFeed operation.
/// </summary>
public sealed record GetFeedRequest
{
    public required string FeedId { get; init; }
}
