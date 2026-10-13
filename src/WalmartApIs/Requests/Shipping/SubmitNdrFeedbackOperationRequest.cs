using WalmartApIs.Models;

namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the SubmitNdrFeedback operation.
/// </summary>
public sealed record SubmitNdrFeedbackOperationRequest
{
    public required SubmitNdrFeedbackRequest Body { get; init; }
}
