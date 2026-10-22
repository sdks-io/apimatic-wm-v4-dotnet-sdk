using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Seller accountable drivers, which impacting the valid tracking rate
/// </summary>
public record SellerAccountableVtrDrivers
{
    /// <summary>
    /// Total rate of orders with misleading tracking information
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("misleadingTrackingRate")]
    public double? MisleadingTrackingRate { get; init; }

    /// <summary>
    /// Total rate of orders with non Integrated Carriers
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("nonIntegratedCarrierRate")]
    public double? NonIntegratedCarrierRate { get; init; }

    /// <summary>
    /// Total rate of orders with invalid tracking Id
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("invalidTrackingIdRate")]
    public double? InvalidTrackingIdRate { get; init; }

    /// <summary>
    /// Total rate of orders with invalid tracking url
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("invalidTrackingUrlRate")]
    public double? InvalidTrackingUrlRate { get; init; }

    /// <summary>
    /// Total rate of orders with no Carrier Scan
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("noCarrierScanRate")]
    public double? NoCarrierScanRate { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
