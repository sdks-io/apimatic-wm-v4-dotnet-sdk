using System;
using System.Collections.Generic;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Reports;

/// <summary>
/// The inputs of the GetReports operation.
/// </summary>
public sealed record GetReportsRequest
{
    /// <summary>
    /// Filter by report type. Values are Walmart Partner Reporting Platform enum names. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.
    /// </summary>
    public IReadOnlyList<ReportType1>? ReportTypes { get; init; }

    public IReadOnlyList<ProcessingStatus>? ProcessingStatuses { get; init; }

    public DateTimeOffset? CreatedSince { get; init; }

    public DateTimeOffset? CreatedUntil { get; init; }

    [Minimum(1)]
    [Maximum(100)]
    public int PageSize { get; init; } = 10;

    public string? NextToken { get; init; }
}
