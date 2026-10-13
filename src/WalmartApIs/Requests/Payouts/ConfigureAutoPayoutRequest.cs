using WalmartApIs.Models;

namespace WalmartApIs.Requests.Payouts;

/// <summary>
/// The inputs of the ConfigureAutoPayout operation.
/// </summary>
public sealed record ConfigureAutoPayoutRequest
{
    public required DisbursementsV4PaymentAutoPayoutRequest Body { get; init; }
}
