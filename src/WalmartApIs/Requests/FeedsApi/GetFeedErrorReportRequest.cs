using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.FeedsApi;

/// <summary>
/// The inputs of the GetFeedErrorReport operation.
/// </summary>
public sealed record GetFeedErrorReportRequest
{
    /// <summary>
    /// Feed Id of the feed.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: US only</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string FeedId { get; init; }

    /// <summary>
    /// Feed type for which Error Report needs to be downloaded.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: US only</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required FeedType FeedType { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// The target market of the API call.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

    /// <summary>
    /// The version of the global API used.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
