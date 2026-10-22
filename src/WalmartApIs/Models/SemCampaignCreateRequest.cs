using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record SemCampaignCreateRequest
{
    /// <summary>
    /// Metadata for creating a campaign.
    /// </summary>
    [JsonPropertyName("metadata")]
    public required SemCampaignCreateMetadata Metadata { get; init; }

    /// <summary>
    /// List of operations to perform on campaign items.
    /// </summary>
    [JsonPropertyName("itemsOperations")]
    public required IReadOnlyList<SemCampaignItemsOperation> ItemsOperations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
