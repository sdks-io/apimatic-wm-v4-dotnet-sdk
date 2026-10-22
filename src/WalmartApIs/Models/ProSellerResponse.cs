using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ProSellerResponse
{
    /// <summary>
    /// Specifies if the seller has the badge
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hasBadge")]
    public bool? HasBadge { get; init; }

    /// <summary>
    /// Specifies if the seller is eligible for the badge in the next refresh
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isEligible")]
    public bool? IsEligible { get; init; }

    /// <summary>
    /// Specifies when the seller received their badge
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("badgedSince")]
    public DateTimeOffset? BadgedSince { get; init; }

    /// <summary>
    /// Specifies whether the seller is prohibited from participating in the Pro Seller badge program.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isProhibited")]
    public bool? IsProhibited { get; init; }

    /// <summary>
    /// Specifies the seller's badge status in detail. The possible values are "Become a Pro Seller", "You are a Pro Seller", "Pro Seller Badge at risk", "Eligible starting from YYYY-MM-DD", and "Not eligible for the Pro Seller Badge"
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("badgeStatus")]
    public string? BadgeStatus { get; init; }

    /// <summary>
    /// Shows whether the seller has met the requirements for the badge.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("meetsCriteria")]
    public MeetsCriteria? MeetsCriteria { get; init; }

    /// <summary>
    /// Shows the criteria for the Pro Seller badge.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("criteriaData")]
    public CriteriaData? CriteriaData { get; init; }

    /// <summary>
    /// Recommendations on how to increase chances of Pro Seller Badge eligibility
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("recommendations")]
    public Recommendations? Recommendations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
