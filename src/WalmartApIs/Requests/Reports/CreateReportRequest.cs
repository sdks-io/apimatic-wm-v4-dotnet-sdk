using WalmartApIs.Models;

namespace WalmartApIs.Requests.Reports;

/// <summary>
/// The inputs of the CreateReport operation.
/// </summary>
public sealed record CreateReportRequest
{
    public required CreateReportSpecification Body { get; init; }
}
