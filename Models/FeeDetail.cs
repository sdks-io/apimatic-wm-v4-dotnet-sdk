using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Detail for a single fee component. May nest sub-fees in IncludedFeeDetailList.
/// Mirrors SP-API FeeDetail.
/// </summary>
public record FeeDetail
{
    /// <summary>
    /// Fee type, e.g. ReferralFee, WFSFulfillmentFee, VariableClosingFee.
    /// </summary>
    [JsonPropertyName("FeeType")]
    public required string FeeType { get; init; }

    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonPropertyName("FeeAmount")]
    public required MoneyType1 FeeAmount { get; init; }

    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("FeePromotion")]
    public MoneyType1? FeePromotion { get; init; }

    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("TaxAmount")]
    public MoneyType1? TaxAmount { get; init; }

    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonPropertyName("FinalFee")]
    public required MoneyType1 FinalFee { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
