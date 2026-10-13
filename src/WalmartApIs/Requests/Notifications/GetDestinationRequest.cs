namespace WalmartApIs.Requests.Notifications;

/// <summary>
/// The inputs of the GetDestination operation.
/// </summary>
public sealed record GetDestinationRequest
{
    /// <summary>
    /// The identifier generated when you created the destination.
    /// </summary>
    public required string DestinationId { get; init; }
}
