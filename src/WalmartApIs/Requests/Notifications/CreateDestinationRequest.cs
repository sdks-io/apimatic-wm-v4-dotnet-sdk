namespace WalmartApIs.Requests.Notifications;

/// <summary>
/// The inputs of the CreateDestination operation.
/// </summary>
public sealed record CreateDestinationRequest
{
    public required object Body { get; init; }
}
