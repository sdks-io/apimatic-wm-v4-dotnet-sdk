using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>createMarketplaceItemLabels</c> request.
/// </summary>
public record CreateMarketplaceItemLabelsRequest
{
    /// <summary>
    /// The height of the item label.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height")]
    [Minimum(25.0)]
    [Maximum(100.0)]
    public double? Height { get; init; }

    /// <summary>
    /// Indicates the type of print type for a given label.
    /// </summary>
    [JsonPropertyName("labelType")]
    public required CommonLabelPrintType LabelType { get; init; }

    /// <summary>
    /// The locale code constructed from ISO 639 language code and ISO 3166-1 alpha-2 country codes separated by an underscore character.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("localeCode")]
    [RegularExpression("^[a-z]{2}_[A-Z]{2}$")]
    public string? LocaleCode { get; init; } = "en_US";

    /// <summary>
    /// The Walmart Marketplace ID. For a list of possible values, refer to <see href="https://developer-docs.walmart.com/seller-api/docs/marketplace-ids">Marketplace IDs</see>.
    /// </summary>
    [JsonPropertyName("marketplaceId")]
    [StringLength(20, MinimumLength = 1)]
    public required string MarketplaceId { get; init; }

    /// <summary>
    /// Represents the quantity of an MSKU to print item labels for.
    /// </summary>
    [JsonPropertyName("mskuQuantities")]
    [MinLength(1)]
    [MaxLength(100)]
    public required IReadOnlyList<CommonMskuQuantity> MskuQuantities { get; init; }

    /// <summary>
    /// The page type to use to print the labels.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pageType")]
    public CommonItemLabelPageType? PageType { get; init; }

    /// <summary>
    /// The width of the item label.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width")]
    [Minimum(25.0)]
    [Maximum(100.0)]
    public double? Width { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
