using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>updateItemComplianceDetails</c> request.
/// </summary>
public record UpdateItemComplianceDetailsRequest
{
    /// <summary>
    /// The merchant SKU, a merchant-supplied identifier for a specific SKU.
    /// </summary>
    [JsonPropertyName("msku")]
    [StringLength(255, MinimumLength = 1)]
    public required string Msku { get; init; }

    /// <summary>
    /// Information used to determine the tax compliance.
    /// </summary>
    [JsonPropertyName("taxDetails")]
    public required CommonTaxDetails TaxDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
