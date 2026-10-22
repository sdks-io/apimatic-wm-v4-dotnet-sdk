using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ShipmentProtection;

/// <summary>
/// The inputs of the ListClaims operation.
/// </summary>
public sealed record ListClaimsRequest
{
    /// <summary>
    /// Maximum number of results to return in the response page (default 25, maximum 300).
    /// </summary>
    public int Limit { get; init; } = 25;

    /// <summary>
    /// Zero‑based index of the first result to return (default 0). Use together with <c>limit</c> for pagination.
    /// </summary>
    public int Offset { get; init; } = 0;

    /// <summary>
    /// Filter claims by broad status group: OPEN, ACTION_NEEDED, or CLOSED.
    /// </summary>
    public ClaimsGroup? ClaimsGroup { get; init; }

    /// <summary>
    /// Exact claim number for filtering (query) or identifying a specific claim (path).
    /// </summary>
    public string? ClaimNumber { get; init; }

    /// <summary>
    /// Filter by the Walmart purchase order ID associated with the claim.
    /// </summary>
    public string? PurchaseOrderId { get; init; }

    /// <summary>
    /// Filter by the package tracking number associated with the claim.
    /// </summary>
    public string? TrackingNo { get; init; }

    /// <summary>
    /// Comma‑separated list of claim types to include (LIT, LAD, DAMAGED).
    /// </summary>
    public string? ClaimTypes { get; init; }

    /// <summary>
    /// Comma‑separated list of claim status codes to include (INITIATED, IN_REVIEW, NEED_INFO, etc.).
    /// </summary>
    public string? ClaimStatuses { get; init; }

    /// <summary>
    /// Field to sort by; currently supports <c>claimDate</c>.
    /// </summary>
    public SortBy? SortBy { get; init; }

    /// <summary>
    /// Sort direction: <c>ASC</c> for ascending or <c>DESC</c> for descending (default DESC).
    /// </summary>
    public Order? SortOrder { get; init; }

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
