using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record PaymentProcessorSummary
{
    /// <summary>
    /// Payout year for which tax forms were generated, formatted as YYYY.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payoutYear")]
    public string? PayoutYear { get; init; }

    /// <summary>
    /// Tax forms available for the specified payout year.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("taxForms")]
    public IReadOnlyList<TaxForm>? TaxForms { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
