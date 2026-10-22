using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Prices;

/// <summary>
/// The inputs of the GetStrategies operation.
/// </summary>
public sealed record GetStrategiesRequest
{
    /// <summary>
    /// The response object starts at 0, representing the first entity that can be retrieved.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX&lt;/b&gt;
    /// </summary>
    public string Offset { get; init; } = "0";

    /// <summary>
    /// The number of entities to return, with a maximum limit of 25.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX&lt;/b&gt;
    /// </summary>
    public string Limit { get; init; } = "10";

    /// <summary>
    /// A unique ID which identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// Identifies the Walmart Marketplace region for the request. If not specified, US is used by default.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public required WmMarket1 WmMarket { get; init; }

    /// <summary>
    /// Indicates the global version of the API. The default is set to 3.1.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    public required WmGlobalVersion WmGlobalVersion { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
