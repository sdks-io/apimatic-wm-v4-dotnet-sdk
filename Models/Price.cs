using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Schema for price info in getPricing response.
/// </summary>
public record Price
{
    /// <summary>
    /// The status of the operation.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; init; }

    /// <summary>
    /// The seller stock keeping unit (SKU) of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("SellerSKU")]
    public string? SellerSku { get; init; }

    /// <summary>
    /// The Walmart Item ID of the item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("walmartItemId")]
    public string? WalmartItemId { get; init; }

    /// <summary>
    /// An item.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Product")]
    public Product? Product { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
