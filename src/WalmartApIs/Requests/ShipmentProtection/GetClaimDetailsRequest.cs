namespace WalmartApIs.Requests.ShipmentProtection;

/// <summary>
/// The inputs of the GetClaimDetails operation.
/// </summary>
public sealed record GetClaimDetailsRequest
{
    /// <summary>
    /// Exact claim number for filtering (query) or identifying a specific claim (path).
    /// </summary>
    public required string ClaimNumber { get; init; }

    /// <summary>
    /// The access token retrieved in the Token API call.
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and is used to track and debug issues; use a randomly generated GUID for this ID.
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart service name—for Marketplace APIs simply use <c>Walmart Service Name</c> or the service identifier provided by Walmart.
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
