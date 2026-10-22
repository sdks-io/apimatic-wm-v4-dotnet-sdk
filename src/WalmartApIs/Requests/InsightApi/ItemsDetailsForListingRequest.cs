using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.InsightApi;

/// <summary>
/// The inputs of the ItemsDetailsForListing operation.
/// </summary>
public sealed record ItemsDetailsForListingRequest
{
    /// <summary>
    /// Specify number of items to return. If no limit is specified, API returns 200 items by default.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string Limit { get; init; } = "200";

    /// <summary>
    /// Specify pagination for long list of items.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public string? NextCursor { get; init; }

    /// <summary>
    /// Specify pagination for long list of items.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX&lt;/b&gt;
    /// </summary>
    public string? Offset { get; init; }

    /// <summary>
    /// GLOBAL VERSION DEFAULT AS 3.1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. Required for authenticating requests to Walmart Marketplace APIs.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the Consumer Channel Type received during onboarding.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Request payload
    /// </summary>
    public required V3InsightsItemsListingQualityItemsRequest Body { get; init; }
}
