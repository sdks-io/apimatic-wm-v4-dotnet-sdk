using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Payload2
{
    /// <summary>
    /// total count for unpublished Item
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unpublishedCount")]
    public string? UnpublishedCount { get; init; }

    /// <summary>
    /// total value for unpublished Item
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unpublishedValue")]
    public string? UnpublishedValue { get; init; }

    /// <summary>
    /// the reason why item is unpublished
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unpublishedReasonCode")]
    public string? UnpublishedReasonCode { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
