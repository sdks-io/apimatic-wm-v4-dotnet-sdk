using WalmartApIs.Models;

namespace WalmartApIs.Requests.MerchantFulfillment;

/// <summary>
/// The inputs of the GetEligibleShippingServices operation.
/// </summary>
public sealed record GetEligibleShippingServicesOperationRequest
{
    public required GetEligibleShippingServicesRequest Body { get; init; }
}
