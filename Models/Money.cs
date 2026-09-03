using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record Money
{
    /// <summary>
    /// Monetary amount as string to preserve precision
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("amount")]
    public string? Amount { get; init; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; init; } = "USD";

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
