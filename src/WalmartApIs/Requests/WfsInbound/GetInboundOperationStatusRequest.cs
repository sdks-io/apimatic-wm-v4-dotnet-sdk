namespace WalmartApIs.Requests.WfsInbound;

/// <summary>
/// The inputs of the GetInboundOperationStatus operation.
/// </summary>
public sealed record GetInboundOperationStatusRequest
{
    /// <summary>
    /// Identifier of an asynchronous operation.
    /// </summary>
    public required string OperationId { get; init; }
}
