using WalmartApIs.Models;

namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the GetRates operation.
/// </summary>
public sealed record GetRatesOperationRequest
{
    public required GetRatesRequest Body { get; init; }
}
