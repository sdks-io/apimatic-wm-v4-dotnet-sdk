using WalmartApIs.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.InventoryApi;

/// <summary>
/// The inputs of the UpdateInventoryForAnItem operation.
/// </summary>
public sealed record UpdateInventoryForAnItemRequest
{
    /// <summary>
    /// An arbitrary alphanumeric unique ID, specified by the seller, which identifies each item. This will be used by the seller in the XSD file to refer to each item. Special characters in the sku needing encoding are: ':', '/', '?', '#', '[', ']', '@', '!', '$', '&amp;', "'", '(', ')', '*', '+', ',', ';', '=', ‘ ’, '{', '}' as well as '%' itself if it's a part of sku. Make sure to encode space with %20. Other characters don't need to be encoded.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string Sku { get; init; }

    /// <summary>
    /// The shipNode for which the inventory is to be updated.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? ShipNode { get; init; }

    /// <summary>
    /// Access token obtained from the Token API. Required for authenticating requests to Walmart Marketplace APIs.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmSecAccessToken { get; init; }

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

    /// <summary>
    /// File fields
    /// </summary>
    public required V3InventoryRequest Body { get; init; }
}
