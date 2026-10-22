using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Item-level performance data with product details.
/// <para>
/// <b>Note</b>: Item details (<c>itemName</c>, <c>productType</c>, <c>category</c>) are enriched from the
/// seller's catalogue and may be null if the item is not found.
/// </para>
/// </summary>
public record WsrItemData
{
    /// <summary>
    /// External campaign identifier.
    /// Available for all performanceBy levels (<c>CAMPAIGN</c>, <c>ADGROUP</c>, <c>CREATIVE</c>).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("campaignId")]
    public string? CampaignId { get; init; }

    /// <summary>
    /// External ad group identifier.
    /// <para>
    /// &gt; <b>Note:</b> Only populated when <c>performanceBy</c> is <c>ADGROUP</c> or <c>CREATIVE</c>. Returns <c>null</c> for campaign-level aggregation.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("adGroupId")]
    public string? AdGroupId { get; init; }

    /// <summary>
    /// External creative/link identifier.
    /// <para>
    /// &gt; <b>Note:</b> Only populated when <c>performanceBy</c> is <c>CREATIVE</c>. Returns <c>null</c> for campaign and adgroup-level aggregation..
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("creativeId")]
    public string? CreativeId { get; init; }

    /// <summary>
    /// Walmart item identifier
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemId")]
    public string? ItemId { get; init; }

    /// <summary>
    /// Name of the item/product from catalogue.
    /// May be null if item not found in seller's catalogue.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemName")]
    public string? ItemName { get; init; }

    /// <summary>
    /// Product type classification from catalogue.
    /// May be null if item not found in seller's catalogue.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("productType")]
    public string? ProductType { get; init; }

    /// <summary>
    /// Product category from catalogue.
    /// May be null if item not found in seller's catalogue.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("category")]
    public string? Category { get; init; }

    /// <summary>
    /// Performance metrics for the aggregated data.
    /// <para>
    /// All metrics are based on last-touch attribution with a 14-day window.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("metrics")]
    public WsrMetrics? Metrics { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
