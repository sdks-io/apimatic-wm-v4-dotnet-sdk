using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3RepricerStrategyRequest
{
    /// <summary>
    /// Specifies the name of the strategy collection. This value is used to group and manage related repricing strategies.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("repricerStrategy")]
    public string? RepricerStrategy { get; init; }

    /// <summary>
    /// Indicates the current status of the strategy collection.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; init; }

    /// <summary>
    /// Indicates whether the item is eligible for promotional repricing. Set this to true to enable repricing for promotional items.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enableRepricerForPromotion")]
    public bool? EnableRepricerForPromotion { get; init; }

    /// <summary>
    /// Reprices the item price back to the last submitted price if no competitor price is found.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("restoreSellerPriceWithoutTarget")]
    public bool? RestoreSellerPriceWithoutTarget { get; init; }

    /// <summary>
    /// Indicates whether to match external competitor prices to beat the Buy Box price. This is only applicable for Buy Box strategies.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("enableBuyboxMeetExternal")]
    public bool? EnableBuyboxMeetExternal { get; init; }

    /// <summary>
    /// Indicates whether to compare only against 3P offers.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("compareWith3pOfferOnly")]
    public bool? CompareWith3POfferOnly { get; init; }

    /// <summary>
    /// Defines one or more repricing strategies to apply.&lt;br&gt;&lt;b style="color:green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("strategies")]
    public IReadOnlyList<Strategy>? Strategies { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
