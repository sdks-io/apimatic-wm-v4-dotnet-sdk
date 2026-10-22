using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Box items. This is a mandatory field for India(IN) to United States(US) shipping
/// </summary>
public record EstimatesBoxItem
{
    /// <summary>
    /// sku of an item
    /// </summary>
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// Quantity of Item
    /// </summary>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// PO Line Number
    /// </summary>
    [JsonPropertyName("lineNumber")]
    public required string LineNumber { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
