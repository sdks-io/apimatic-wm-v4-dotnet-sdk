using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.ReturnsRefund;

/// <summary>
/// The inputs of the RefundRequest operation.
/// </summary>
public sealed record RefundRequestOperationRequest
{
    /// <summary>
    /// Return order identifier of the return order object as part of array. This is the same as RMA number.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    public required string ReturnOrderId { get; init; }

    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.
    /// Example: b3261d2d-028a-4ef7-8602-633c23200af6&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// Example: Walmart Marketplace&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    public required WmMarket3 WmMarket { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The value must be set to 3.1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the Consumer Channel Type received during onboarding.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/b&gt;
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    public required RefundRequest Body { get; init; }
}
