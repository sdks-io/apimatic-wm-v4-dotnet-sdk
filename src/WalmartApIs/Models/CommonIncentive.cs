using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains details about cost related modifications to the placement cost.
/// </summary>
public record CommonIncentive
{
    /// <summary>
    /// Description of the incentive.
    /// </summary>
    [JsonPropertyName("description")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Description { get; init; }

    /// <summary>
    /// Target of the incentive. Possible values: 'Placement Services', 'Fulfillment Fee Discount'.
    /// </summary>
    [JsonPropertyName("target")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Target { get; init; }

    /// <summary>
    /// Type of incentive. Possible values: <c>FEE</c>, <c>DISCOUNT</c>.
    /// </summary>
    [JsonPropertyName("type")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Type { get; init; }

    /// <summary>
    /// The type and amount of currency.
    /// </summary>
    [JsonPropertyName("value")]
    public required CommonCurrency Value { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
