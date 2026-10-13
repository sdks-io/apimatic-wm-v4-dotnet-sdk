using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The type and amount of currency.
/// </summary>
public record CommonCurrency
{
    /// <summary>
    /// Decimal value of the currency.
    /// </summary>
    [JsonPropertyName("amount")]
    public required double Amount { get; init; }

    /// <summary>
    /// ISO 4217 standard currency code.
    /// </summary>
    [JsonPropertyName("code")]
    [StringLength(3, MinimumLength = 3)]
    public required string Code { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
