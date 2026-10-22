using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record OAuthTokenDto
{
    /// <summary>
    /// Access token to be used for accessing business APIs
    /// </summary>
    [JsonPropertyName("accessToken")]
    public required string AccessToken { get; init; }

    /// <summary>
    /// Type of token according to user. (e.g., 'BEARER')
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tokenType")]
    public string? TokenType { get; init; }

    /// <summary>
    /// Expiry time of access token in seconds
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiresIn")]
    public int? ExpiresIn { get; init; }

    /// <summary>
    /// Token which should be used to refresh access token.&lt;br /&gt; This field is present in response when <b>grant_type: authorization_code</b>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
