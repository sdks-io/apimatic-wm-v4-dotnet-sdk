using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Promotions;

/// <summary>
/// The inputs of the PriceBulkUploads operation.
/// </summary>
public sealed record PriceBulkUploadsRequest
{
    /// <summary>
    /// The feed Type. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required FeedType21 FeedType { get; init; }

    /// <summary>
    /// The access token retrieved in the Token API call. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

    /// <summary>
    /// Global Version is set to 3.1 by default. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// The request body consists of a Feed file attached to the request based on the feedType selected
    /// </summary>
    public V3FeedsFeedTypePriceAndPromotionRequest1? Body { get; init; }
}
