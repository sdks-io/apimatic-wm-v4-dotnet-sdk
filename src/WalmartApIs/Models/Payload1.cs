using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Payload in the response having the details about the item recommendations.
/// </summary>
public record Payload1
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ITEM | To get list of recommended items | string |
    /// </summary>
    [JsonPropertyName("recommendationType")]
    public string RecommendationType { get; } = "ITEM";

    /// <summary>
    /// Meta information for the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meta")]
    public MetaDataResponse? Meta { get; init; }

    /// <summary>
    /// Information related to the item recommendations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("records")]
    public IReadOnlyList<Record>? Records { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
