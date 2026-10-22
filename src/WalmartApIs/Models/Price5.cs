using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record Price5
{
    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerId")]
    public string? OfferId { get; init; }

    [JsonPropertyName("sku")]
    public required string Sku { get; init; }

    /// <summary>
    /// This is applicable only for promotions
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("replaceAll")]
    public ReplaceAll? ReplaceAll { get; init; }

    [JsonPropertyName("pricing")]
    public required IReadOnlyList<Pricing> Pricing { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("definitions")]
    public object? Definitions { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
