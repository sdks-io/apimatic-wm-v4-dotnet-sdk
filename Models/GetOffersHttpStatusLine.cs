using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// The HTTP status line associated with the response.
/// </summary>
public record GetOffersHttpStatusLine
{
    /// <summary>
    /// The HTTP response Status Code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("statusCode")]
    [Minimum(100)]
    [Maximum(599)]
    public int? StatusCode { get; init; }

    /// <summary>
    /// The HTTP response Reason-Phrase.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reasonPhrase")]
    public string? ReasonPhrase { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
