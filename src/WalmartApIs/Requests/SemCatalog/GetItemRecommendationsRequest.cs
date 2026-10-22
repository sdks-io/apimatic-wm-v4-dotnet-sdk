namespace WalmartApIs.Requests.SemCatalog;

/// <summary>
/// The inputs of the GetItemRecommendations operation.
/// </summary>
public sealed record GetItemRecommendationsRequest
{
    /// <summary>
    /// Specifies the maximum number of recommended items to be returned. This value cannot exceed 200.
    /// </summary>
    public int Limit { get; init; } = 100;

    /// <summary>
    /// Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs.
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
