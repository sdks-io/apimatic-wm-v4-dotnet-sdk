using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Dynamic Client Registration error (RFC 7591 §3.2.2).
/// </summary>
public record RegistrationErrorError
{
    /// <summary>
    /// Machine-readable error code.
    /// </summary>
    [JsonPropertyName("error")]
    public required Error2 Error { get; init; }

    /// <summary>
    /// Human-readable explanation.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_description")]
    public string? ErrorDescription { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
