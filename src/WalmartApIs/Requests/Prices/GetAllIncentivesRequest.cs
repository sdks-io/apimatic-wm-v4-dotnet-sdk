using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Prices;

/// <summary>
/// The inputs of the GetAllIncentives operation.
/// </summary>
public sealed record GetAllIncentivesRequest
{
    /// <summary>
    /// Specify the incentive status to retrieve items with ELIGIBLE or ENROLLED incentives. Allowed values include ENROLLED and ELIGIBLE.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    public IncentiveStatus IncentiveStatus { get; init; } = IncentiveStatus.Eligible;

    /// <summary>
    /// Specify number of items to return. Max limit value is 200 and min is 1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    public int Limit { get; init; } = 25;

    /// <summary>
    /// Specify the offset of item list to be returned. Min offset value is 0.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    public int Offset { get; init; } = 0;

    /// <summary>
    /// Specify the sort criteria for items. Examples of the allowed values are ITEM_ID, PRODUCT_NAME, CURRENT_PRICE, EXPIRATION_DATE, ENROLLMENT_DATE.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    public SortBy1 SortBy { get; init; } = SortBy1.ExpirationDate;

    /// <summary>
    /// Specify the sort order for given sort criteria. Examples of the allowed values are ASC or DESC.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    public Order SortOrder { get; init; } = Order.Desc;

    /// <summary>
    /// Specify the incentive type to filter the incentive items. Allowed values include REDUCED_REFERRAL, WALMART_FUNDED.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    public IncentiveType? IncentiveType { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The default is set to 3.1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
