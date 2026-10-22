using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ShipWithWalmart;

/// <summary>
/// The inputs of the GetScanFormByManifestId operation.
/// </summary>
public sealed record GetScanFormByManifestIdRequest
{
    /// <summary>
    /// Manifest ID returned by the create scan form API. Use this value to download the scan form document.
    /// </summary>
    public required string ManifestId { get; init; }

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
    /// Case-sensitive market identifier. Valid values: US
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmMarket WmMarket { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The value must be set to 3.1.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// Requested response media type. This endpoint returns a binary document stream (application/octet-stream). Treat the response body as bytes.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string Accept { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
