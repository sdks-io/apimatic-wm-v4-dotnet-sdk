using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record CreateSimplifiedShippingSettingsRequest
{
    /// <summary>
    /// Simplified Shipping Settings
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("simplifiedShippingSettings")]
    public SimplifiedAccountShippingSettingsDto? SimplifiedShippingSettings { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
