using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ShipWithWalmart;

/// <summary>
/// The inputs of the DiscardLabel operation.
/// </summary>
public sealed record DiscardLabelRequest
{
    /// <summary>
    /// The short name of the shipping carrier.&lt;br&gt;Use the carrierShortName value returned from the Supported Carriers API to ensure compatibility.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string CarrierShortName { get; init; }

    /// <summary>
    /// The shipment tracking number.
    /// <para>
    ///
    /// </para>
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string TrackingNo { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID. &lt;br&gt; Example: b3261d2d-028a-4ef7-8602-633c23200af6 &lt;br&gt; &lt;b style="color: green;"&gt;Market availability: Global &lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called. &lt;br&gt; Example: Walmart Marketplace.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global &lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default. Valid values: MX, US
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global &lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmMarket6 WmMarket { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The value must be set to 3.1.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global &lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global &lt;/b&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
