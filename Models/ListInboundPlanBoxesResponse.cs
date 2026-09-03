using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listInboundPlanBoxes</c> response., The <c>listPackingGroupBoxes</c> response., The <c>listShipmentBoxes</c> response.
/// </summary>
public record ListInboundPlanBoxesResponse
{
    /// <summary>
    /// A list of boxes in an inbound plan.
    /// </summary>
    [JsonPropertyName("boxes")]
    public required IReadOnlyList<CommonBox> Boxes { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
