using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.AnyOf;

namespace WalmartApIs.Models;

public record SupplierItemPayload
{
    [JsonPropertyName("Orderable")]
    public required SupplierItemOrderable Orderable { get; init; }

    /// <summary>
    /// The visible block for rich media. The expected structure depends on <c>SupplierItemFeedHeader.subCategory</c>. Discriminator is based on <c>SupplierItemFeedHeader.subCategory</c>
    /// </summary>
    [JsonPropertyName("Visible")]
    public required Visible Visible { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
