using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Seller accountable drivers, which impacting the refunds rate
/// </summary>
public record SellerAccountableRefundsDrivers
{
    /// <summary>
    /// Refund rate of incorrect items delivered
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("incorrectItemsRate")]
    public double? IncorrectItemsRate { get; init; }

    /// <summary>
    /// Refund rate of delivered late orders
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("arrivedLateRate")]
    public double? ArrivedLateRate { get; init; }

    /// <summary>
    /// Refund rate of defective orders
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("defectiveRate")]
    public double? DefectiveRate { get; init; }

    /// <summary>
    /// Refund rate of damaged orders
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("damagedRate")]
    public double? DamagedRate { get; init; }

    /// <summary>
    /// Refund rate of lost orders
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lostRate")]
    public double? LostRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
