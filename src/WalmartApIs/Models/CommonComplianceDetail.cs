using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains item identifiers and related tax information.
/// </summary>
public record CommonComplianceDetail
{
    /// <summary>
    /// The merchant SKU, a merchant-supplied identifier for a specific SKU.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("msku")]
    [StringLength(255, MinimumLength = 1)]
    public string? Msku { get; init; }

    /// <summary>
    /// Information used to determine the tax compliance.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxDetails")]
    public CommonTaxDetails? TaxDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
