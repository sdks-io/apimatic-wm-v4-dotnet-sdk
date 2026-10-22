using System.Text.Json.Serialization;

namespace WalmartApIs.Models;

public record PromotionFeedPriceItem
{
    /// <summary>
    /// Applicable for CA, MX, and CL markets. Price details for the item. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("Price")]
    public required Price12 Price { get; init; }
}
