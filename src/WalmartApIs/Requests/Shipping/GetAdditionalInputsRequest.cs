namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the GetAdditionalInputs operation.
/// </summary>
public sealed record GetAdditionalInputsRequest
{
    /// <summary>
    /// rateId returned by a prior getRates response.
    /// </summary>
    public required string RateId { get; init; }

    /// <summary>
    /// requestToken returned by a prior getRates response.
    /// </summary>
    public required string RequestToken { get; init; }
}
