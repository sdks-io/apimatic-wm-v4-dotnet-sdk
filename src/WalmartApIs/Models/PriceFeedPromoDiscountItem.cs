using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record PriceFeedPromoDiscountItem
{
    /// <summary>
    /// The field ‘Promo&amp;Discount’ is for the US market. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("Promo&Discount")]
    public required PromoDiscount PromoDiscount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
