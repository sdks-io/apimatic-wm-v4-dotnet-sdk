using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Quantity of an item that is input by the seller
/// </summary>
public record InputQty
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
