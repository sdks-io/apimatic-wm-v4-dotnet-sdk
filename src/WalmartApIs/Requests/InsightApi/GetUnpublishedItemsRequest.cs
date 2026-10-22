using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.InsightApi;

/// <summary>
/// The inputs of the GetUnpublishedItems operation.
/// </summary>
public sealed record GetUnpublishedItemsRequest
{
    /// <summary>
    /// Returns all unpublished items since the given date&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public required string FromDate { get; init; }

    /// <summary>
    /// Unpublished reason code&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string UnpublishedReasonCode { get; init; } = "all";

    /// <summary>
    /// The number of items to be returned.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string Limit { get; init; } = "20";

    /// <summary>
    /// The lifecycle status of an item describes where the item listing is in the overall lifecycle. Examples of allowed values are ACTIVE , ARCHIVED, RETIRED.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string OfferLifecycleStatus { get; init; } = "all";

    /// <summary>
    /// Filter the item list to return only items that are trending on Walmart.com&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string MarketTrending { get; init; } = "true";

    /// <summary>
    /// Filter the item list to return only items that have inventory&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public string ItemsWithInventory { get; init; } = "true";

    /// <summary>
    /// Filters items by customer favorite status. When set to <c>true</c>, only customer favorites are returned. When set to <c>false</c>, only non-favorites are returned. If omitted, all items are returned.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    public bool? IsCustomerFavorite { get; init; }

    /// <summary>
    /// GLOBAL VERSION DEFAULT AS 3.1&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. Required for authenticating requests to Walmart Marketplace APIs.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSecAccessToken { get; init; }

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
