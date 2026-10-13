using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listInboundPlanPallets</c> response., The <c>listShipmentPallets</c> response.
/// </summary>
public record ListInboundPlanPalletsResponse
{
    /// <summary>
    /// The pallets in an inbound plan.
    /// </summary>
    [JsonPropertyName("pallets")]
    public required IReadOnlyList<CommonPallet> Pallets { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
