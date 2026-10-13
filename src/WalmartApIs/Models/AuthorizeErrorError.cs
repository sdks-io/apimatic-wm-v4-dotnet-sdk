using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Authorization-endpoint error (RFC 6749 §4.1.2.1) — non-redirectable case only.
/// </summary>
public record AuthorizeErrorError
{
    /// <summary>
    /// Machine-readable error code.
    /// </summary>
    [JsonPropertyName("error")]
    public required Error1 Error { get; init; }

    /// <summary>
    /// Human-readable explanation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; init; }

    /// <summary>
    /// Optional link to error docs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_uri")]
    [Format(FormatKind.Uri)]
    public string? ErrorUri { get; init; }

    /// <summary>
    /// The <c>state</c> from the request, when supplied.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("state")]
    public string? State { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
