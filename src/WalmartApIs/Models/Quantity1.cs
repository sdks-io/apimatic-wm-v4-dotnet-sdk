using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// quantity.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
/// </summary>
public record Quantity1
{
    /// <summary>
    /// currency.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("unitOfMeasurement")]
    public string? UnitOfMeasurement { get; init; }

    /// <summary>
    /// amount.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("amount")]
    public string? Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
