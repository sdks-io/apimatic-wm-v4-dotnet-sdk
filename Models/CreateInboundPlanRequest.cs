using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>createInboundPlan</c> request.
/// </summary>
public record CreateInboundPlanRequest
{
    /// <summary>
    /// Walmart Marketplace IDs where the items need to be shipped to. Currently only one marketplace can be selected.
    /// </summary>
    [JsonPropertyName("destinationMarketplaces")]
    [MinLength(1)]
    [MaxLength(1)]
    public required IReadOnlyList<string> DestinationMarketplaces { get; init; }

    /// <summary>
    /// Items included in this plan.
    /// </summary>
    [JsonPropertyName("items")]
    [MinLength(1)]
    [MaxLength(2000)]
    public required IReadOnlyList<CommonItemInput> Items { get; init; }

    /// <summary>
    /// Name for the Inbound Plan. If one isn't provided, a default name will be provided.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    [StringLength(40, MinimumLength = 1)]
    public string? Name { get; init; }

    /// <summary>
    /// Specific details to identify a place (input variant — phone required).
    /// </summary>
    [JsonPropertyName("sourceAddress")]
    public required CommonAddressInput SourceAddress { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
