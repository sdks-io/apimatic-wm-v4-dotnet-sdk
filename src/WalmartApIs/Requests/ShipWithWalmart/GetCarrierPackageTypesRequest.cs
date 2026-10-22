using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ShipWithWalmart;

/// <summary>
/// The inputs of the GetCarrierPackageTypes operation.
/// </summary>
public sealed record GetCarrierPackageTypesRequest
{
    /// <summary>
    /// carrierShortName fetched from carrier API response or pass 'ALL' to fetch all package types of supported carriers
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string CarrierShortName { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs.&lt;br&gt; Example: eyJraWQiOiIxNWNhNGIyYi0yODVjLTQ0ZDUtYmExNC05ZDk1NTlkZmUwNjgiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiZGlyIn0....
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and is used to track and debug issues. Use a random generated GUID for this ID.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default. Valid values: MX, CA, CL.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmMarket11 WmMarket { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The value must be set to 3.1.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
