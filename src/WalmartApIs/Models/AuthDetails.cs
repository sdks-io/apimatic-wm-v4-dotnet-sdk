using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Authentication details for accessing the destination URL, if the URL is protected.
/// </summary>
public record AuthDetails
{
    /// <summary>
    /// Authentication method for the destination URL. Allowed values: BASIC_AUTH, OAUTH, HMAC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("authMethod")]
    public string? AuthMethod { get; init; }

    /// <summary>
    /// Username used to access the destination URL (required for BASIC_AUTH).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("userName")]
    public string? UserName { get; init; }

    /// <summary>
    /// Password used to access the destination URL (required for BASIC_AUTH).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("password")]
    public string? Password { get; init; }

    /// <summary>
    /// Header name used to pass the authorization value to the destination URL (for example, Authorization).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("authHeaderName")]
    public string? AuthHeaderName { get; init; }

    /// <summary>
    /// OAuth server or token URL used when the authentication method is OAUTH.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("authUrl")]
    public string? AuthUrl { get; init; }

    /// <summary>
    /// Client secret used with the OAuth server (OAUTH) or as key material for HMAC.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; init; }

    /// <summary>
    /// Client ID used with the OAuth server when the authentication method is OAUTH.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("clientId")]
    public string? ClientId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
