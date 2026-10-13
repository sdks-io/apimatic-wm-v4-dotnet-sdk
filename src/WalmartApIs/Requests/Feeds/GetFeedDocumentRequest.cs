using System.ComponentModel.DataAnnotations;

namespace WalmartApIs.Requests.Feeds;

/// <summary>
/// The inputs of the GetFeedDocument operation.
/// </summary>
public sealed record GetFeedDocumentRequest
{
    [RegularExpression("^[A-Za-z0-9._@-]+$")]
    public required string FeedId { get; init; }
}
