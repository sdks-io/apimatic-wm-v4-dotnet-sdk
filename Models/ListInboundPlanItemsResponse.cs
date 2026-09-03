using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listInboundPlanItems</c> response., The <c>listPackingGroupItems</c> response., The <c>listShipmentItems</c> response.
/// </summary>
public record ListInboundPlanItemsResponse
{
    /// <summary>
    /// The items in an inbound plan.
    /// </summary>
    [JsonPropertyName("items")]
    public required IReadOnlyList<CommonItem> Items { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
