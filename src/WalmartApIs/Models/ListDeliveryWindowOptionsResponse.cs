using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listDeliveryWindowOptions</c> response.
/// </summary>
public record ListDeliveryWindowOptionsResponse
{
    /// <summary>
    /// Delivery window options generated for the shipment.
    /// </summary>
    [JsonPropertyName("deliveryWindowOptions")]
    public required IReadOnlyList<CommonDeliveryWindowOption> DeliveryWindowOptions { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
