using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ShipWithWalmart;

/// <summary>
/// The inputs of the CreateLabel operation.
/// </summary>
public sealed record CreateLabelRequest
{
    /// <summary>
    /// Specifies the desired response format. The order of media types determines the priority for format selection.
    /// <para>
    /// <b>Supported values:</b>
    /// - <c>application/json</c> : Returns tracking information only (no label file).
    /// - <c>application/json, application/pdf</c> : Returns the label in PDF format.
    /// - <c>application/json, image/png</c> : Returns the label in PNG format.
    /// </para>
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string Accept { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. This is required for authenticating requests to Walmart Marketplace APIs.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.&lt;br&gt;Example: Walmart Marketplace
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Case-sensitive market identifier. Valid values: MX, CA, CL, US
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

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

    /// <summary>
    /// Label fields
    /// </summary>
    public required V3ShippingLabelsRequest Body { get; init; }
}
