using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// RFC 7591 §2 client metadata.
/// </summary>
public record ClientRegistrationRequest
{
    /// <summary>
    /// Registered callback URIs. Enforced by exact match at authorize. HTTPS (or localhost).
    /// </summary>
    [JsonPropertyName("redirect_uris")]
    public required IReadOnlyList<string> RedirectUris { get; init; }

    /// <summary>
    /// <c>none</c> for public clients (PKCE), <c>client_secret_post</c>/<c>client_secret_basic</c> for confidential.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("token_endpoint_auth_method")]
    public TokenEndpointAuthMethod? TokenEndpointAuthMethod { get; init; } = TokenEndpointAuthMethod.None;

    /// <summary>
    /// Grants the client will use.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("grant_types")]
    public IReadOnlyList<GrantType1>? GrantTypes { get; init; }

    /// <summary>
    /// Must be <c>[code]</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("response_types")]
    public IReadOnlyList<ResponseType>? ResponseTypes { get; init; }

    /// <summary>
    /// Human-readable name shown on the consent screen.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_name")]
    public string? ClientName { get; init; }

    /// <summary>
    /// Space-delimited scopes the client may request (subset of the sellerAuth catalog + <c>offline_access</c>).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    /// <summary>
    /// Homepage of the client.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_uri")]
    [Format(FormatKind.Uri)]
    public string? ClientUri { get; init; }

    /// <summary>
    /// Logo shown on the consent screen.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("logo_uri")]
    [Format(FormatKind.Uri)]
    public string? LogoUri { get; init; }

    /// <summary>
    /// Contact emails for the client.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contacts")]
    public IReadOnlyList<string>? Contacts { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
