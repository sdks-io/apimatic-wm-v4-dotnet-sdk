using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Performance data aggregated by the specified performance level.
/// <para>
/// <b>Field Availability by <c>performanceBy</c></b>:
/// </para>
/// <para>
/// | Field | CAMPAIGN | ADGROUP | CREATIVE |
/// |:--|:--:|:--:|:--:|
/// | <c>campaignId</c> | ✓ | ✓ | ✓ |
/// | <c>adGroupId</c> | null | ✓ | ✓ |
/// | <c>creativeId</c> | null | null | ✓ |
/// </para>
/// </summary>
public record WsrPerformanceData
{
    /// <summary>
    /// External campaign identifier.
    /// Available for all performanceBy levels (CAMPAIGN, ADGROUP, CREATIVE).
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
    /// &gt; <b>Note:</b> Only populated when <c>performanceBy</c> is <c>CREATIVE</c>. Returns <c>null</c> for campaign and adgroup-level aggregation.
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("creativeId")]
    public string? CreativeId { get; init; }

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
