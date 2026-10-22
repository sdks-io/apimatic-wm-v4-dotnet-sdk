using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Individual error detail
/// </summary>
public record WsrErrorDetail
{
    /// <summary>
    /// Error code of the response.
    /// <para>
    /// <b>Common Codes</b>:
    /// - <c>SA_4000</c>: Bad request / validation error
    /// - <c>SA_4001</c>: Unauthorized
    /// - <c>SA_4003</c>: Forbidden
    /// - <c>SA_5000</c>: Internal server error
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("code")]
    public string? Code { get; init; }

    /// <summary>
    /// Human-readable description of the error
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
