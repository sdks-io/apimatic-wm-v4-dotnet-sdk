using WalmartApIs.Models;

namespace WalmartApIs.Requests.RecommendationsApi;

/// <summary>
/// The inputs of the GetShipmentQuantityRecommendations operation.
/// </summary>
public sealed record GetShipmentQuantityRecommendationsRequest
{
    /// <summary>
    /// Basic authorization header. Base 64 encodes the Client ID and Client Secret retrieved in step two of the integration steps.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string Authorization { get; init; }

    /// <summary>
    /// The access token retrieved in the Token API call
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

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
    /// Market identifier.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmMarket { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Request body containing GTINs or SKUs to retrieve the quantity limit.
    /// <para>
    /// &lt;b style='color: green;'&gt;Market availability: US only&lt;/b&gt;
    /// </para>
    /// </summary>
    public required V3WfsRecommendationShipmentQuantityRequest Body { get; init; }
}
