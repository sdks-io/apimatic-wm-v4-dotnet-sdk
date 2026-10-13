using WalmartApIs.Models;

namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the SetPrepDetails operation.
/// </summary>
public sealed record SetPrepDetailsOperationRequest
{
    public required SetPrepDetailsRequest Body { get; init; }
}
