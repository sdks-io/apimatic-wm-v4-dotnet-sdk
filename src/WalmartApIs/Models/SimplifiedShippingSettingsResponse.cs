using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record SimplifiedShippingSettingsResponse
{
    /// <summary>
    /// Simplified Shipping Settings
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("simplifiedShippingSettings")]
    public SimplifiedShippingSettingsDto? SimplifiedShippingSettings { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
