using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalmartApIs.Models;

namespace WalmartApIs.Requests.ProductFees;

/// <summary>
/// The inputs of the GetMyFeesEstimates operation.
/// </summary>
public sealed record GetMyFeesEstimatesRequest
{
    [MaxLength(20)]
    public required IReadOnlyList<FeesEstimateByIdRequest> Body { get; init; }
}
