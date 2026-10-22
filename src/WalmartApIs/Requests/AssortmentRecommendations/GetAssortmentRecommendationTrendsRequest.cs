using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.AssortmentRecommendations;

/// <summary>
/// The inputs of the GetAssortmentRecommendationTrends operation.
/// </summary>
public sealed record GetAssortmentRecommendationTrendsRequest
{
    /// <summary>
    /// Unique ID that is returned in the response of the get recommendations API or in the on-request bulk CSV file. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    public required string RecommendationUniqueId { get; init; }

    /// <summary>
    /// Comma separated list of trends.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// <para>
    ///  | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | PRICE_TRENDS | Indicates the price trends for the recommended item in the marketplace currency for rolling 52-weeks/12-months. The data may not be available for all weeks/months. | string |
    /// | DEMAND_TRENDS | Indicates the demand trends for the recommended item for 52-weeks/12-months. | string |
    /// </para>
    /// </summary>
    public string? TrendTypes { get; init; }

    /// <summary>
    /// GLOBAL VERSION DEFAULT AS 3.1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/span&gt;&lt;/b&gt;
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
