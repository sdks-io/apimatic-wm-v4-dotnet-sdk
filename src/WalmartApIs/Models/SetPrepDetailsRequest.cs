using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>setPrepDetails</c> request.
/// </summary>
public record SetPrepDetailsRequest
{
    /// <summary>
    /// The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.
    /// </summary>
    [JsonPropertyName("marketplaceId")]
    [StringLength(20, MinimumLength = 1)]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// A list of MSKUs and related prep details.
    /// </summary>
    [JsonPropertyName("mskuPrepDetails")]
    [MinLength(1)]
    [MaxLength(100)]
    public required IReadOnlyList<CommonMskuPrepDetailInput> MskuPrepDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
