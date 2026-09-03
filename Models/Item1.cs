using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Item1
{
    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("summaries")]
    public IReadOnlyList<ItemSummaryByMarketplace>? Summaries { get; init; }

    /// <summary>
    /// Item attribute key-value pairs for the listing
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("attributes")]
    public object? Attributes { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issues")]
    public IReadOnlyList<Issue>? Issues { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offers")]
    public IReadOnlyList<ItemOfferByMarketplace>? Offers { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fulfillmentAvailability")]
    public IReadOnlyList<FulfillmentAvailability>? FulfillmentAvailability { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
