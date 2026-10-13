using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// OAuth 2.0 token-endpoint error (RFC 6749 §5.2).
/// </summary>
public record OAuthErrorError
{
    /// <summary>
    /// Machine-readable error code.
    /// </summary>
    [JsonPropertyName("error")]
    public required Error Error { get; init; }

    /// <summary>
    /// Human-readable explanation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; init; }

    /// <summary>
    /// Optional link to error documentation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_uri")]
    [Format(FormatKind.Uri)]
    public string? ErrorUri { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
