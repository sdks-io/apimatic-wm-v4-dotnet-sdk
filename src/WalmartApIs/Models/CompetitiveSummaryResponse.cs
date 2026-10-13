using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// An individual competitive summary response.
/// </summary>
public record CompetitiveSummaryResponse
{
    /// <summary>
    /// The HTTP status line associated with the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    public GetOffersHttpStatusLine? Status { get; init; }

    /// <summary>
    /// The body of a competitive summary response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("body")]
    public CompetitiveSummaryResponseBody? Body { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
