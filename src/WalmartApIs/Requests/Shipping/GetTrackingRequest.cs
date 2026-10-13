namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the GetTracking operation.
/// </summary>
public sealed record GetTrackingRequest
{
    /// <summary>
    /// Tracking identifier returned by purchaseShipment.
    /// </summary>
    public required string TrackingId { get; init; }

    /// <summary>
    /// Optional carrier identifier for defense-in-depth validation
    /// against TNT's resolved carrier. Not required by TNT itself
    /// -- omit unless you specifically want mismatch protection.
    /// </summary>
    public string? CarrierId { get; init; }
}
