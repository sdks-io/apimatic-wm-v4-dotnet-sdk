using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.InsightApi;

/// <summary>
/// The inputs of the GetUnpublishedItemCount operation.
/// </summary>
public sealed record GetUnpublishedItemCountRequest
{
    /// <summary>
    /// Returns all unpublished items count with reason codes since the given date period&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    public required string FromDate { get; init; }

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
