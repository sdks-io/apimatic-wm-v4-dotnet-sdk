using System.ComponentModel.DataAnnotations;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Authorization;

/// <summary>
/// The inputs of the Authorize operation.
/// </summary>
public sealed record AuthorizeRequest
{
    /// <summary>
    /// Must be <c>code</c>.
    /// </summary>
    public required ResponseType1 ResponseType { get; init; }

    /// <summary>
    /// The registered client identifier.
    /// </summary>
    public required string ClientId { get; init; }

    /// <summary>
    /// Callback URI; must exactly match a registered value.
    /// </summary>
    [Format(FormatKind.Uri)]
    public required string RedirectUri { get; init; }

    /// <summary>
    /// Space-delimited scopes. Include <c>offline_access</c> to receive a refresh token.
    /// </summary>
    public required string Scope { get; init; }

    /// <summary>
    /// Opaque CSRF token; echoed back unchanged.
    /// </summary>
    public required string State { get; init; }

    /// <summary>
    /// PKCE challenge — base64url(SHA-256(code_verifier)).
    /// </summary>
    [StringLength(128, MinimumLength = 43)]
    [RegularExpression("^[A-Za-z0-9-._~]+$")]
    public required string CodeChallenge { get; init; }

    /// <summary>
    /// Must be <c>S256</c>.
    /// </summary>
    public required CodeChallengeMethod CodeChallengeMethod { get; init; }
}
