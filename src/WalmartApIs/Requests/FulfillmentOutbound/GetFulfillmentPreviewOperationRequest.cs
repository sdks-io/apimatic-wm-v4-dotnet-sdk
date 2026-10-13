using WalmartApIs.Models;

namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the GetFulfillmentPreview operation.
/// </summary>
public sealed record GetFulfillmentPreviewOperationRequest
{
    public required GetFulfillmentPreviewRequest Body { get; init; }
}
