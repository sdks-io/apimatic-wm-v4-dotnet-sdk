using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Common properties of batch requests against individual APIs.
/// </summary>
public record BatchRequest
{
    /// <summary>
    /// The resource path of the operation being called in batch, without query parameters.
    /// </summary>
    [JsonPropertyName("uri")]
    public required string Uri { get; init; }

    /// <summary>
    /// The HTTP method associated with the individual APIs being called as part of the batch request.
    /// </summary>
    [JsonPropertyName("method")]
    public required HttpMethodEnum Method { get; init; }

    /// <summary>
    /// A mapping of additional HTTP headers to send for the individual batch request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headers")]
    public object? Headers { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
