using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Seller accountable drivers, which impacting the on time delivery rate
/// </summary>
public record SellerAccountableOtdDrivers
{
    /// <summary>
    /// Rate of orders impacted due to late shipment
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lateShipmentRate")]
    public double? LateShipmentRate { get; init; }

    /// <summary>
    /// Rate of orders delivered later than estimated delivery date
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierEDDLaterThanEDDRate")]
    public double? CarrierEddLaterThanEddRate { get; init; }

    /// <summary>
    /// Rate of orders impacted due to late handover to carrier
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("lateHandoverToCarrierRate")]
    public double? LateHandoverToCarrierRate { get; init; }

    /// <summary>
    /// Rate of orders impacted due to no carrier scan
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("noCarrierScanRate")]
    public double? NoCarrierScanRate { get; init; }

    /// <summary>
    /// Rate of orders impacted due to shipping method mismatch
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierMethodMismatchRate")]
    public double? CarrierMethodMismatchRate { get; init; }

    /// <summary>
    /// Rate of orders impacted due to ship location mismatch
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipLocationMismatchRate")]
    public double? ShipLocationMismatchRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
