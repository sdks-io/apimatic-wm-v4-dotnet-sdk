using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Tax
{
    /// <summary>
    /// Name of the tax.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US,MX&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxName")]
    public string? TaxName { get; init; }

    /// <summary>
    /// Amount of excess tax in the order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US &lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("excessTax")]
    public ExcessTax? ExcessTax { get; init; }

    /// <summary>
    /// Price of One unit of item, in this order line.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability:  US&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxPerUnit")]
    public TaxPerUnit? TaxPerUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
