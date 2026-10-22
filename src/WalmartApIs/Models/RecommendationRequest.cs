using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record RecommendationRequest
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ITEM | To get list of recommended items | string |
    /// </summary>
    [JsonPropertyName("recommendationType")]
    public string RecommendationType { get; } = "ITEM";

    /// <summary>
    /// Meta information for the request.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meta")]
    public MetaDataRequest? Meta { get; init; }

    /// <summary>
    /// Different type of filters can be passed in this object.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filterCriteria")]
    public RecommendationRequestFilter? FilterCriteria { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
