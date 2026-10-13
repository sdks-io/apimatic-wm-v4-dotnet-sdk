using System;
using System.Collections.Generic;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Feeds;

/// <summary>
/// The inputs of the GetFeeds operation.
/// </summary>
public sealed record GetFeedsRequest
{
    /// <summary>
    /// Feed type filter
    /// </summary>
    public IReadOnlyList<FeedType>? FeedTypes { get; init; }

    public IReadOnlyList<FeedStatus>? FeedStatuses { get; init; }

    public DateTimeOffset? CreatedSince { get; init; }

    public DateTimeOffset? CreatedUntil { get; init; }

    [Minimum(1)]
    [Maximum(100)]
    public int PageSize { get; init; } = 10;

    public string? NextToken { get; init; }
}
