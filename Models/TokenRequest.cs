using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Form-encoded token request. Fields required depend on <c>grant_type</c>:
/// <c>client_credentials</c> (client auth only), <c>authorization_code</c>
/// (<c>code</c> + <c>code_verifier</c>), <c>refresh_token</c> (<c>refresh_token</c>).
/// </summary>
public record TokenRequest
{
    /// <summary>
    /// The OAuth grant type.
    /// </summary>
    [JsonPropertyName("grant_type")]
    public required GrantType GrantType { get; init; }

    /// <summary>
    /// Client identifier (client_secret_post / public clients). Omit if using HTTP Basic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; init; }

    /// <summary>
    /// Client secret (client_secret_post). Omit for public clients or HTTP Basic.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; init; }

    /// <summary>
    /// Authorization code from <c>/auth/v4/authorize</c> (authorization_code grant).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// PKCE verifier whose S256 hash equals the earlier <c>code_challenge</c> (authorization_code grant).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("code_verifier")]
    [StringLength(128, MinimumLength = 43)]
    [RegularExpression("^[A-Za-z0-9-._~]+$")]
    public string? CodeVerifier { get; init; }

    /// <summary>
    /// A previously issued refresh token (refresh_token grant). Rotated on use.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("refresh_token")]
    public string? RefreshToken { get; init; }

    /// <summary>
    /// Accepted for OAuth 2.0 back-compat on authorization_code; not required in 2.1 (PKCE covers injection).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("redirect_uri")]
    [Format(FormatKind.Uri)]
    public string? RedirectUri { get; init; }

    /// <summary>
    /// <b>client_credentials:</b> accepted for compatibility but <b>not honored</b>
    ///  — no down-scoping; not echoed. <b>refresh_token:</b> optional;
    /// MUST NOT exceed the originally granted scope.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
