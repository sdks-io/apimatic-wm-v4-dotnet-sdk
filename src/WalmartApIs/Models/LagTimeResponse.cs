using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record LagTimeResponse
{
    /// <summary>
    /// A seller-provided Product ID. The response will have a decoded value of the SKU.
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// The number of days between when the item is ordered and when it is shipped.
    /// </summary>
    [JsonPropertyName("fulfillmentLagTime")]
    public required int FulfillmentLagTime { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
