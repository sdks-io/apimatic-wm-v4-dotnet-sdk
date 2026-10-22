using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.SeoRecommendations;

/// <summary>
/// The inputs of the UpdateSeoRecommendations operation.
/// </summary>
public sealed record UpdateSeoRecommendationsRequest
{
    /// <summary>
    /// Unique Item Identifier
    /// </summary>
    public required string ItemId { get; init; }

    /// <summary>
    /// approve/reject a recommendation
    /// </summary>
    public required Decision Decision { get; init; }

    /// <summary>
    /// The access token retrieved in the Token API call
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Only supported Media Type : application/json
    /// </summary>
    public required string Accept { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Additional details required for submission
    /// </summary>
    public V3SeoRecommendationUpdateItemsRequest? Body { get; init; }
}
