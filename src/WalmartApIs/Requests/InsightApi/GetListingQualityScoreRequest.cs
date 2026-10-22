using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.InsightApi;

/// <summary>
/// The inputs of the GetListingQualityScore operation.
/// </summary>
public sealed record GetListingQualityScoreRequest
{
    /// <summary>
    /// Specify whether or not to include seller's items that are trending in the Listing Quality Score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public bool? ViewTrendingItems { get; init; }

    /// <summary>
    /// Specify whether or not to include WFS-eligible items in the overall Listing Quality Score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string? WfsFlag { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The value must be set to 3.1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
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
}
