using System;
using System.Collections.Generic;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.DataKiosk;

/// <summary>
/// The inputs of the GetQueries operation.
/// </summary>
public sealed record GetQueriesRequest
{
    public IReadOnlyList<ProcessingStatus>? ProcessingStatuses { get; init; }

    [Minimum(1)]
    [Maximum(100)]
    public int PageSize { get; init; } = 10;

    public DateTimeOffset? CreatedSince { get; init; }

    public DateTimeOffset? CreatedUntil { get; init; }

    public string? PaginationToken { get; init; }
}
