using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Quantity of an item that is available to be allocated to orders.
/// </summary>
public record AvailToSellQty
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
