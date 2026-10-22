using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Quantity that has been ordered by the customers but not yet shipped.
/// </summary>
public record SupplyQuantity
{
    /// <summary>
    /// The unit of measurement. Example: 'EACH'
    /// </summary>
    [JsonPropertyName("unit")]
    public string Unit { get; } = "EACH";

    /// <summary>
    /// Inventory Count
    /// </summary>
    [JsonPropertyName("amount")]
    public required double Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
