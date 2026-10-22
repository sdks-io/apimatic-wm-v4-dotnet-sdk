using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.SeoRecommendations;

/// <summary>
/// The inputs of the GetSeoRecommendations operation.
/// </summary>
public sealed record GetSeoRecommendationsRequest
{
    /// <summary>
    /// Specifies the type of items to retrieve. Default when type not provided it will return new items.
    /// </summary>
    public Status2? Status { get; init; }

    /// <summary>
    /// Specify number of items to return. If no limit is specified, API returns 200 items by default.
    /// </summary>
    public string? Limit { get; init; }

    /// <summary>
    /// Link to go to the next page
    /// </summary>
    public string? NextCursor { get; init; }

    /// <summary>
    /// Link to go to the previous page
    /// </summary>
    public string? PreviousCursor { get; init; }

    /// <summary>
    /// The access tok  en retrieved in the Token API call
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
    /// This will contain the wild card search related details
    /// </summary>
    public V3SeoRecommendationGetItemsRequest? Body { get; init; }
}
