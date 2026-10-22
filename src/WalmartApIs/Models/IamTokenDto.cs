using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record IamTokenDto
{
    /// <summary>
    /// Type of grant requested. &lt;br /&gt; <b>Available grant types:</b> authorization_code, refresh_token and client_credentials
    /// </summary>
    [JsonPropertyName("grant_type")]
    public GrantType GrantType { get; init; } = GrantType.ClientCredentials;

    /// <summary>
    /// Authorization code obtained by your client app when the seller authorizes your app to access the seller resource. &lt;br /&gt; This field is required when <b>grant_type: authorization_code</b>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("code")]
    public string? Code { get; init; } = "65CA5DA313A549D49D15D3119D9AD85D";

    /// <summary>
    /// This should be same as one of your client app URIs provided while registering the app. &lt;br /&gt; This field is required when <b>grant_type: authorization_code</b>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; init; } = "https://example-client-app.com";

    /// <summary>
    /// Refresh token received as response of Authentication API with authorization_code grant type, to be used to refresh the access token. &lt;br /&gt; This field is required when <b>grant_type: refresh_token</b>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; } = "APXcIoTpKMH9OQN.....";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
