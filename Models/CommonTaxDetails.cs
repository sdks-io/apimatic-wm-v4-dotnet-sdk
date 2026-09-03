using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Information used to determine the tax compliance.
/// </summary>
public record CommonTaxDetails
{
    /// <summary>
    /// The type and amount of currency.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("declaredValue")]
    public CommonCurrency? DeclaredValue { get; init; }

    /// <summary>
    /// Harmonized System of Nomenclature code.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hsnCode")]
    [StringLength(1024, MinimumLength = 1)]
    public string? HsnCode { get; init; }

    /// <summary>
    /// List of tax rates.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxRates")]
    public IReadOnlyList<CommonTaxRate>? TaxRates { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
