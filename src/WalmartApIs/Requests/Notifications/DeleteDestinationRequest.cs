namespace WalmartApIs.Requests.Notifications;

/// <summary>
/// The inputs of the DeleteDestination operation.
/// </summary>
public sealed record DeleteDestinationRequest
{
    /// <summary>
    /// The identifier for the destination that you want to delete.
    /// </summary>
    public required string DestinationId { get; init; }
}
