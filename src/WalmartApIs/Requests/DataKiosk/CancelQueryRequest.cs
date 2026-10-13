namespace WalmartApIs.Requests.DataKiosk;

/// <summary>
/// The inputs of the CancelQuery operation.
/// </summary>
public sealed record CancelQueryRequest
{
    public required string QueryId { get; init; }
}
