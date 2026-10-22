using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Item-level diagnostic data including product details, campaign associations, overall item status, and list of issues.
/// <para>
/// Each <c>ActiveItemIssues</c> object appears <b>once</b> per unique <c>offerId</c>.
/// The <c>campaignAssociations</c> array lists all campaigns the item belongs to.
/// Issues are <b>item-level</b>, not campaign-specific — the same issue applies regardless of which campaign the item is in.
/// </para>
/// <para>
/// ### Identifier Contract
/// | Field     | Source           | Format                  | Description                                                              |
/// |-----------|------------------|-------------------------|--------------------------------------------------------------------------|
/// | <c>offerId</c> | Walmart-assigned | String                  | Uniquely identifies a specific offer (item + seller). Recommended primary key for partner systems. |
/// | <c>itemId</c>  | Walmart-assigned | Numeric string          | Walmart catalog item identifier. Shared across sellers offering the same product. |
/// | <c>sku</c>     | Partner-assigned | Alphanumeric (partner-defined) | The partner's own SKU. Never a Walmart-assigned value.               |
/// </para>
/// </summary>
public record ActiveItemIssues
{
    /// <summary>
    /// Unique offer identifier. Enables deep-linking, correlation with partner
    /// inventory systems, and disambiguation of items across campaigns.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("offerId")]
    public string? OfferId { get; init; }

    /// <summary>
    /// Walmart catalog item identifier (numeric string).
    /// Shared across sellers offering the same product.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemId")]
    public string? ItemId { get; init; }

    /// <summary>
    /// Partner-assigned Stock Keeping Unit.
    /// Always the partner's own SKU, never a Walmart-assigned value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("sku")]
    public string? Sku { get; init; }

    /// <summary>
    /// Product image URL.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productImageUrl")]
    public string? ProductImageUrl { get; init; }

    /// <summary>
    /// Product display name.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productName")]
    public string? ProductName { get; init; }

    /// <summary>
    /// List of all campaigns this item is associated with.
    /// A single item may participate in multiple campaigns.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("campaignAssociations")]
    public IReadOnlyList<CampaignRef>? CampaignAssociations { get; init; }

    /// <summary>
    /// Overall SEM eligibility status derived from all issues affecting this item.
    /// <list type="bullet">
    ///   <item><description><b>NO_ISSUES</b>: Item has no SEM issues and can be advertised on search engines with full visibility</description></item>
    ///   <item><description><b>LIMITED</b>: Item has issues that reduce its visibility or performance in Search Engine Marketing</description></item>
    ///   <item><description><b>BLOCKED</b>: Item has critical issues that completely prevent it from being advertised on search engines</description></item>
    /// </list>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueCategory")]
    public IssueCategory? IssueCategory { get; init; }

    /// <summary>
    /// Link to item on Walmart.com.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productUrl")]
    public string? ProductUrl { get; init; }

    /// <summary>
    /// List of issues affecting this item.
    /// Each issue contains an <c>issueType</c> that can be used as a lookup key
    /// into the issue metadata returned by the <c>GET /item-issues/issue-types</c> endpoint.
    /// Empty array when item has no issues.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issues")]
    public IReadOnlyList<Issue>? Issues { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
