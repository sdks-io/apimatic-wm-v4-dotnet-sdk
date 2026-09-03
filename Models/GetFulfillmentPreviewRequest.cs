using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record GetFulfillmentPreviewRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("marketplaceId")]
    public string? MarketplaceId { get; init; }

    [JsonPropertyName("address")]
    public required Address Address { get; init; }

    [JsonPropertyName("items")]
    public required IReadOnlyList<GetFulfillmentPreviewItem> Items { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingSpeedCategories")]
    public IReadOnlyList<ShippingSpeedCategory>? ShippingSpeedCategories { get; init; }

    [JsonPropertyName("includeCODFulfillmentPreview")]
    public bool? IncludeCodFulfillmentPreview { get; init; } = false;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
