using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record SemCampaignUpdateRequest
{
    /// <summary>
    /// Metadata for updating the campaign.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metadata")]
    public SemCampaignUpdateMetadata? Metadata { get; init; }

    /// <summary>
    /// List of operations to perform on campaign items.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemsOperations")]
    public IReadOnlyList<SemCampaignItemsOperation>? ItemsOperations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
