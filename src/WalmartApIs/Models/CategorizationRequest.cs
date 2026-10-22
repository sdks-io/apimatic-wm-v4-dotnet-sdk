using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record CategorizationRequest
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | BRAND | To get list of brands which are associated with the assortment recommendations | string |
    /// | CATEGORY | To get list of categories which are associated with the assortment recommendations | string |
    /// </summary>
    [JsonPropertyName("categorizationType")]
    public required CategorizationType CategorizationType { get; init; }

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
    public CategorizationRequestFilter? FilterCriteria { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
