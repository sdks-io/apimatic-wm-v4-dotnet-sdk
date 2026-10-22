using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Payload in the response having the categorization details about the item recommendations.
/// </summary>
public record CategorizationResponsePayload
{
    /// <summary>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | BRAND | To get list of brands which are associated with the assortment recommendations | string |
    /// | CATEGORY | To get list of categories which are associated with the assortment recommendations | string |
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("categorizationType")]
    public CategorizationType? CategorizationType { get; init; }

    /// <summary>
    /// Meta information for the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meta")]
    public MetaDataResponse? Meta { get; init; }

    /// <summary>
    /// Information of item recommendations based on the categorizationType.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("records")]
    public IReadOnlyList<CategorizationFacet>? Records { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
