using System.Collections.Generic;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.RichMedia;

/// <summary>
/// The inputs of the GetAllAssets operation.
/// </summary>
public sealed record GetAllAssetsRequest
{
    /// <summary>
    /// Indicates the page number to return in the paginated result set. Use this parameter to navigate through multiple pages of results. The value should be a positive integer. For example, 1 for the first page, 2 for the second, and so on.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// Defines the maximum number of items to return per page when retrieving paginated data. Use this parameter to control the number of results included in a single page. The value should be a positive integer.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public int Limit { get; init; } = 25;

    /// <summary>
    /// Filters assets by linked GTIN. Provide multiple GTINs as a list. If omitted, all assets are returned.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public IReadOnlyList<string>? LinkedGtins { get; init; }

    /// <summary>
    /// Filters assets by rich media title or asset title. If omitted, all assets are returned.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public string? RichMediaTitle { get; init; }

    /// <summary>
    /// Filters assets by rich media type. Allowed values: <c>IMAGES360</c>, <c>VIDEO</c>.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public RichMediaType? RichMediaType { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the consumer channel type received during onboarding.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
