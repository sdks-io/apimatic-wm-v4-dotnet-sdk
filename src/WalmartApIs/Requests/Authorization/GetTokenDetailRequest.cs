namespace WalmartApIs.Requests.Authorization;

/// <summary>
/// The inputs of the GetTokenDetail operation.
/// </summary>
public sealed record GetTokenDetailRequest
{
    /// <summary>
    /// The access token retrieved in the Token API call
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmSecAccessToken { get; init; }

    /// <summary>
    /// Available marketplace location: us (USA), mx (Mexico), ca (Canada) or cl (Chile)
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmMarket { get; init; }

    /// <summary>
    /// Content type of the request body.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string ContentType { get; init; }

    /// <summary>
    /// A unique ID which identifies each API call and used to track and debug issues; use a random generated GUID for this ID
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Walmart Service Name
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }
}
