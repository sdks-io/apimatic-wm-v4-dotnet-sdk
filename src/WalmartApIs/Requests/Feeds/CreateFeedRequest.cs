using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Feeds;

/// <summary>
/// The inputs of the CreateFeed operation.
/// </summary>
public sealed record CreateFeedRequest
{
    /// <summary>
    /// The type of feed being submitted
    /// </summary>
    public required FeedType FeedType { get; init; }

    /// <summary>
    /// Marketplace identifier (opaque token). If omitted, the service applies WALMART_US.
    /// </summary>
    public string? MarketplaceId { get; init; }

    /// <summary>
    /// The feed content file to upload and process
    /// </summary>
    public required BinaryContent File { get; init; }

    /// <summary>
    /// MIME type of the uploaded feed content.
    /// If omitted, the server infers from the file's Content-Type in the multipart header.
    /// </summary>
    public ContentType? ContentType { get; init; }
}
