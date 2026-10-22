using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Price of One unit of item, in this order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  US&lt;/b&gt;
/// </summary>
public record TaxPerUnit
{
    /// <summary>
    /// Amount to be refunded.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currencyAmount")]
    public double? CurrencyAmount { get; init; }

    /// <summary>
    /// Currency information.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currencyUnit")]
    public string? CurrencyUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
