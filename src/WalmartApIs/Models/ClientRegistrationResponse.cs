using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// RFC 7591 §3.2.1 registration response.
/// </summary>
public record ClientRegistrationResponse
{
    /// <summary>
    /// Issued client identifier.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; init; }

    /// <summary>
    /// Issue time (Unix epoch seconds).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_id_issued_at")]
    public long? ClientIdIssuedAt { get; init; }

    /// <summary>
    /// Issued only for confidential clients. Treat as a secret; never log.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; init; }

    /// <summary>
    /// Secret expiry (Unix epoch seconds); 0 = never. Absent for public clients.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_secret_expires_at")]
    public long? ClientSecretExpiresAt { get; init; }

    /// <summary>
    /// Registered callback URIs.
    /// </summary>
    [JsonPropertyName("redirect_uris")]
    public required IReadOnlyList<string> RedirectUris { get; init; }

    /// <summary>
    /// The registered client authentication method.
    /// </summary>
    [JsonPropertyName("token_endpoint_auth_method")]
    public required string TokenEndpointAuthMethod { get; init; }

    /// <summary>
    /// Registered grant types.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("grant_types")]
    public IReadOnlyList<string>? GrantTypes { get; init; }

    /// <summary>
    /// Registered client name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("client_name")]
    public string? ClientName { get; init; }

    /// <summary>
    /// Registered scopes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public string? Scope { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
