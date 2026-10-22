using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// List of operations to perform on campaign items.
/// </summary>
public record SemCampaignItemsOperation
{
    /// <summary>
    /// Type of operation to perform on campaign items. Allowed values: <c>ADD</c> or <c>REMOVE</c>.
    /// </summary>
    [JsonPropertyName("operationType")]
    public required OperationType OperationType { get; init; }

    /// <summary>
    /// List of SKUs associated with the campaign. Must contain between 1 and 10,000 SKUs.
    /// </summary>
    [JsonPropertyName("skus")]
    public required IReadOnlyList<string> Skus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
