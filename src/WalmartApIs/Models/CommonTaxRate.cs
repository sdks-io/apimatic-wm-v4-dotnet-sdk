using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains the type and rate of tax.
/// </summary>
public record CommonTaxRate
{
    /// <summary>
    /// Rate of cess tax.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("cessRate")]
    public double? CessRate { get; init; }

    /// <summary>
    /// Rate of gst tax.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("gstRate")]
    public double? GstRate { get; init; }

    /// <summary>
    /// Type of tax. Possible values: <c>CGST</c>, <c>SGST</c>, <c>IGST</c>, <c>TOTAL_TAX</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxType")]
    [StringLength(1024, MinimumLength = 1)]
    public string? TaxType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
