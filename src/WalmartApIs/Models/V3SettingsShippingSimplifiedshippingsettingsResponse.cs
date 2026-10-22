using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3SettingsShippingSimplifiedshippingsettingsResponse
{
    /// <summary>
    /// Simplified Shipping Settings.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("simplifiedShippingSettings")]
    public SimplifiedShippingSettings12? SimplifiedShippingSettings { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
