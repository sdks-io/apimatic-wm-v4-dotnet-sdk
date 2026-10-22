using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Authorization;

/// <summary>
/// The inputs of the TokenApi operation.
/// </summary>
public sealed record TokenApiRequest
{
    /// <summary>
    /// Available marketplace location: us (USA), mx (Mexico), ca (Canada) or cl (Chile)
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public required string WmMarket { get; init; }

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
    /// Partner Id registered in Walmart marketplace to identify a seller. &lt;br /&gt; This field is required when <b>grant_type: authorization_code</b> and <b>grant_type: refresh_token</b>
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? WmPartnerId { get; init; }

    /// <summary>
    /// A unique ID to track the consumer request by channel. Use the Consumer Channel Type received during onboarding.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Type of grant requested. &lt;br /&gt; <b>Available grant types:</b> authorization_code, refresh_token and client_credentials
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public GrantType1 GrantType { get; init; } = GrantType1.ClientCredentials;

    /// <summary>
    /// Authorization code obtained by your client app when the seller authorizes your app to access the seller resource. &lt;br /&gt; This field is required when <b>grant_type: authorization_code</b>
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? Code { get; init; }

    /// <summary>
    /// This should be same as one of your client app URIs provided while registering the app. &lt;br /&gt; This field is required when <b>grant_type: authorization_code</b>
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? RedirectUri { get; init; }

    /// <summary>
    /// Refresh token received as response of Authentication API with authorization_code grant type, to be used to refresh the access token. The token lifetime is 1 year.
    /// <para>
    /// &lt;strong style="color: green;"&gt;<b>Market availability: Global</b>&lt;/strong&gt;
    /// </para>
    /// </summary>
    public string? RefreshToken { get; init; }
}
