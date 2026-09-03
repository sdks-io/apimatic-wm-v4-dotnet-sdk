using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Breakdown of units that cannot be fulfilled.
/// </summary>
public record UnfulfillableQuantity
{
    /// <summary>
    /// Total units that cannot be fulfilled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalUnfulfillableQuantity")]
    [Minimum(0)]
    public int? TotalUnfulfillableQuantity { get; init; }

    /// <summary>
    /// Units damaged by a customer return.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customerDamagedQuantity")]
    [Minimum(0)]
    public int? CustomerDamagedQuantity { get; init; }

    /// <summary>
    /// Units damaged in the fulfillment center.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("warehouseDamagedQuantity")]
    [Minimum(0)]
    public int? WarehouseDamagedQuantity { get; init; }

    /// <summary>
    /// Units damaged by the distributor.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("distributorDamagedQuantity")]
    [Minimum(0)]
    public int? DistributorDamagedQuantity { get; init; }

    /// <summary>
    /// Units damaged in transit by a carrier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierDamagedQuantity")]
    [Minimum(0)]
    public int? CarrierDamagedQuantity { get; init; }

    /// <summary>
    /// Units identified as defective.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("defectiveQuantity")]
    [Minimum(0)]
    public int? DefectiveQuantity { get; init; }

    /// <summary>
    /// Units that have passed their expiration date.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiredQuantity")]
    [Minimum(0)]
    public int? ExpiredQuantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
