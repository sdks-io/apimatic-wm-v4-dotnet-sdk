using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record OAuthTokenModel
{
    /// <summary>
    /// Access token to be used for accessing business APIs
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; } = "eyJraWQiOiI1MWY3MjM0Ny0wYWY5LTRhZ....";

    /// <summary>
    /// Type of token according to user. (e.g., 'BEARER')
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; init; } = "Bearer";

    /// <summary>
    /// Expiry time of access token in seconds
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; init; } = 900;

    /// <summary>
    /// Token which should be used to refresh access token.&lt;br /&gt; This field is present in response when <b>grant_type: authorization_code</b>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; } = "APXcIoTpKMH9OQN…….";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
