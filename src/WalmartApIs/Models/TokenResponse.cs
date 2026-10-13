using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record TokenResponse
{
    /// <summary>
    /// Opaque Bearer access token. Treat as a secret; never log.
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    /// <summary>
    /// Always <c>Bearer</c> (RFC 6750).
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; } = "Bearer";

    /// <summary>
    /// Access-token lifetime in seconds (≈900 today).
    /// </summary>
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }

    /// <summary>
    /// Rotated refresh token — replaces the one presented (OAuth 2.1 §4.3.1).
    /// Present only on delegated grants when <c>offline_access</c> was granted.
    /// Treat as a secret; never log.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; }

    /// <summary>
    /// Space-delimited granted scopes; present on delegated grants when narrowed from the original grant.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
