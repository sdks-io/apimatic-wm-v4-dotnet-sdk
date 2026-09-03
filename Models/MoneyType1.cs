using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Currency amount.
/// </summary>
public record MoneyType1
{
    /// <summary>
    /// Three-digit currency code (ISO 4217).
    /// </summary>
    [JsonPropertyName("CurrencyCode")]
    public required string CurrencyCode { get; init; }

    [JsonPropertyName("Amount")]
    public required double Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
