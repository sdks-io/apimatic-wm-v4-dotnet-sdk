using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record SupplierItemOrderable
{
    /// <summary>
    /// Product GTIN (Global Trade Item Number) — the unique product identifier.
    /// </summary>
    [JsonPropertyName("productId")]
    public required string ProductId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
