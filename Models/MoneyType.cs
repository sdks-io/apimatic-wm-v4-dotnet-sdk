using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Currency type and monetary value.
/// </summary>
public record MoneyType
{
    /// <summary>
    /// The currency code in ISO 4217 format.
    /// </summary>
    [JsonPropertyName("CurrencyCode")]
    public string? CurrencyCode { get; init; } = "USD";

    /// <summary>
    /// The monetary value.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Amount")]
    public double? Amount { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
