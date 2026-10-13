using WalmartApIs.Models;

namespace WalmartApIs.Requests.FinalPayout;

/// <summary>
/// The inputs of the UpdateFinalPayoutCaseStatus operation.
/// </summary>
public sealed record UpdateFinalPayoutCaseStatusRequest
{
    public required DisbursementsV4FinalPayoutCaseUpdateStatusRequest Body { get; init; }
}
