using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The estimated fees broken down by component.
/// Mirrors SP-API FeesEstimate.
/// </summary>
public record FeesEstimate
{
    [JsonPropertyName("TimeOfFeesEstimation")]
    public required DateTimeOffset TimeOfFeesEstimation { get; init; }

    /// <summary>
    /// Currency amount.
    /// </summary>
    [JsonPropertyName("TotalFeesEstimate")]
    public required MoneyType1 TotalFeesEstimate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("FeeDetailList")]
    public IReadOnlyList<FeeDetail>? FeeDetailList { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
