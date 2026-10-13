namespace WalmartApIs.Requests.DataKiosk;

/// <summary>
/// The inputs of the GetQuery operation.
/// </summary>
public sealed record GetQueryRequest
{
    public required string QueryId { get; init; }
}
