using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The shipping configurations supported for the packing option.
/// </summary>
public record CommonShippingConfiguration
{
    /// <summary>
    /// Mode of shipment transportation. Possible values: <c>GROUND_SMALL_PARCEL</c>, <c>FREIGHT_LTL</c>, <c>FREIGHT_FTL_PALLET</c>, <c>FREIGHT_FTL_NONPALLET</c>, <c>OCEAN_LCL</c>, <c>OCEAN_FCL</c>, <c>AIR_SMALL_PARCEL</c>, <c>AIR_SMALL_PARCEL_EXPRESS</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingMode")]
    [StringLength(1024, MinimumLength = 1)]
    public string? ShippingMode { get; init; }

    /// <summary>
    /// Shipping program for the option. Possible values: <c>WALMART_PARTNERED_CARRIER</c>, <c>USE_YOUR_OWN_CARRIER</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shippingSolution")]
    [StringLength(1024, MinimumLength = 1)]
    public string? ShippingSolution { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
