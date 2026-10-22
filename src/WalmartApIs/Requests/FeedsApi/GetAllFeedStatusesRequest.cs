using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.FeedsApi;

/// <summary>
/// The inputs of the GetAllFeedStatuses operation.
/// </summary>
public sealed record GetAllFeedStatusesRequest
{
    /// <summary>
    /// A unique ID returned from the Bulk Upload API, used for tracking the Feed File. Special characters must be escaped. (e.g., feedId: '...3456@789...' must be entered in the URL as '...3456%40789).
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? FeedId { get; init; }

    /// <summary>
    /// The feedType parameter defines the type of feed whose status you are querying. Feed types are specific to each market, so be sure to provide a value that is supported for your target market.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? FeedType { get; init; }

    /// <summary>
    /// Status of the feed.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public FeedStatus1? FeedStatus { get; init; }

    /// <summary>
    /// The object response to start with, where 0 is the first entity that can be requested.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string Offset { get; init; } = "0";

    /// <summary>
    /// The number of entities to be returned. It cannot be more than 50 entities.
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </summary>
    public string Limit { get; init; } = "50";

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
