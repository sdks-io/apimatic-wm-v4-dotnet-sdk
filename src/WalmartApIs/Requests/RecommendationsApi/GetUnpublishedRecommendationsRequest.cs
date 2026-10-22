using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.RecommendationsApi;

/// <summary>
/// The inputs of the GetUnpublishedRecommendations operation.
/// </summary>
public sealed record GetUnpublishedRecommendationsRequest
{
    /// <summary>
    /// Filters items by customer favorite status. When set to <c>true</c>, only customer favorites are returned. When set to <c>false</c>, only non-favorites are returned. If omitted, all items are returned.
    /// </summary>
    public bool? CustomerFavorite { get; init; }

    /// <summary>
    /// Shows aggregate recommendation values for all items.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public bool ShowInsights { get; init; } = false;

    /// <summary>
    /// The maximum number of SKUs to include in the response (1–300). If you omit this parameter, Walmart returns up to 30 SKUs.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public int Limit { get; init; } = 30;

    /// <summary>
    /// The number of SKUs to skip before Walmart starts listing results. Set to 0 to start at the first SKU.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public int Offset { get; init; } = 0;

    /// <summary>
    /// The attribute to be used in sorting the response.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public string SortBy { get; init; } = "estimatedSalesLift";

    /// <summary>
    /// The order in which the response should be sorted. This can be in set to "ASC" or "DESC" order of value. Default is "DESC.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public SortOrder SortOrder { get; init; } = SortOrder.Desc;

    /// <summary>
    /// Specifies the literal <b>application/json</b>. This value identifies the content type of the request body.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string ContentType { get; init; }

    /// <summary>
    /// Only supported Media Type : application/json.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string Accept { get; init; }

    /// <summary>
    /// Global version for API compatibility.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmGlobalVersion { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmMarket { get; init; }

    /// <summary>
    /// Seller identifier.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmAuditOriginSource { get; init; }
}
