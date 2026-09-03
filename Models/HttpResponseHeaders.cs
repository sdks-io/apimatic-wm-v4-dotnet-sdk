using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A mapping of additional HTTP headers to receive for the individual batch request.
/// </summary>
public record HttpResponseHeaders
{
    /// <summary>
    /// The timestamp that the API request was received.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Date")]
    public string? Date { get; init; }

    /// <summary>
    /// Unique request reference identifier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("X-Request-Id")]
    public string? XRequestId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
