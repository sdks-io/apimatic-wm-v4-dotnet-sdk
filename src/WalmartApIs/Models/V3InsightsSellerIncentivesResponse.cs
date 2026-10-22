using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record V3InsightsSellerIncentivesResponse
{
    /// <summary>
    /// Specifies a unique ID assigned to the partner.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("partnerId")]
    public string? PartnerId { get; init; }

    /// <summary>
    /// Specifies the current tier of the seller on the Marketplace platform.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("currentTier")]
    public string? CurrentTier { get; init; }

    /// <summary>
    /// Specifies the next eligible tier for the seller on the Marketplace platform.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("eligibleTier")]
    public string? EligibleTier { get; init; }

    /// <summary>
    /// Specifies the date when the seller received their badge.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("proSellerBadgeEnrolledDate")]
    public string? ProSellerBadgeEnrolledDate { get; init; }

    /// <summary>
    /// Specifies the metadata value for each criterion&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("criteriaMetadata")]
    public CriteriaMetadata? CriteriaMetadata { get; init; }

    /// <summary>
    /// Specifies the tier for each criterion.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("criteriaTier")]
    public CriteriaTier? CriteriaTier { get; init; }

    /// <summary>
    /// Indicates if the tier has been overridden.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isTierOverride")]
    public bool? IsTierOverride { get; init; }

    /// <summary>
    /// Specifies the overridden tier.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("tierOverride")]
    public string? TierOverride { get; init; }

    /// <summary>
    /// Specifies the reason codes for tier ineligibility.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("reasonCodes")]
    public IReadOnlyList<string>? ReasonCodes { get; init; }

    /// <summary>
    /// Specifies the date of next tier refresh.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nextRefreshDate")]
    public string? NextRefreshDate { get; init; }

    /// <summary>
    /// Specifies the list of rewards.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rewards")]
    public IReadOnlyList<Reward>? Rewards { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
