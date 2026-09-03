using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

/// <summary>
/// Breakdown of reserved quantities.
/// </summary>
public record ReservedQuantity
{
    /// <summary>
    /// Total units reserved across all reservation types.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("totalReservedQuantity")]
    [Minimum(0)]
    public int? TotalReservedQuantity { get; init; }

    /// <summary>
    /// Units reserved for pending customer orders.
    /// Null if no breakdown data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pendingCustomerOrderQuantity")]
    [Minimum(0)]
    public int? PendingCustomerOrderQuantity { get; init; }

    /// <summary>
    /// Units reserved for pending transfers between fulfillment centers.
    /// Null if no breakdown data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pendingTransshipmentQuantity")]
    [Minimum(0)]
    public int? PendingTransshipmentQuantity { get; init; }

    /// <summary>
    /// Units being processed at the fulfillment center (e.g. receiving, labeling).
    /// Null if no data is available.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("fcProcessingQuantity")]
    [Minimum(0)]
    public int? FcProcessingQuantity { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
