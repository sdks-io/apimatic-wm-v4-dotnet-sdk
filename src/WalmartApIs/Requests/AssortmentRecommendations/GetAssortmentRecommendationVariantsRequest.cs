using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.AssortmentRecommendations;

/// <summary>
/// The inputs of the GetAssortmentRecommendationVariants operation.
/// </summary>
public sealed record GetAssortmentRecommendationVariantsRequest
{
    /// <summary>
    /// Primary variant item ID that is returned in the response of get recommendations API or in the on-request bulk CSV file. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    public required string PrimaryVariantItemId { get; init; }

    /// <summary>
    /// Used for pagination when more than 200 records are retrieved. The nextCursor value of the response includes a marker which needs to be passed in next call which retrieves the next page of results. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    public string? NextCursor { get; init; }

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
