using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.InsightApi;

/// <summary>
/// The inputs of the GetCategoriesList operation.
/// </summary>
public sealed record GetCategoriesListRequest
{
    /// <summary>
    /// Specify whether or not to include seller's items that are trending in the Listing Quality Score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public bool ViewTrendingItems { get; init; } = true;

    /// <summary>
    /// Specify whether or not to include WFS-eligible items in the overall Listing Quality Score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public bool? WfsFlag { get; init; }

    /// <summary>
    /// Specify whether or not to include items that have issues in the Listing Quality Score.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public int HasIssue { get; init; } = 0;

    /// <summary>
    /// Specify whether to get item count by brand or category.If not specified, category is the default value.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public Type3? Type { get; init; }

    /// <summary>
    /// Specify whether to get item count by customer favorite.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public bool? InDemandIndicator { get; init; }

    /// <summary>
    /// Specify the number of items to return. The default is 100, with a maximum value of 1000..&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public int? Limit { get; init; }

    /// <summary>
    /// Specify the offset of item list to be returned.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public int Offset { get; init; } = 0;

    /// <summary>
    /// GLOBAL VERSION DEFAULT AS 3.1&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

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
}
