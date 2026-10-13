using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information pertaining to a transportation option and the related carrier.
/// </summary>
public record CommonTransportationOption
{
    /// <summary>
    /// The carrier for the inbound shipment.
    /// </summary>
    [JsonPropertyName("carrier")]
    public required CommonCarrier Carrier { get; init; }

    /// <summary>
    /// Contains details for a transportation carrier appointment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("carrierAppointment")]
    public CommonAppointmentSlotTime? CarrierAppointment { get; init; }

    /// <summary>
    /// Identifies a list of preconditions for confirming the transportation option.
    /// </summary>
    [JsonPropertyName("preconditions")]
    public required IReadOnlyList<string> Preconditions { get; init; }

    /// <summary>
    /// The estimated shipping cost associated with the transportation option.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("quote")]
    public CommonQuote? Quote { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    [JsonPropertyName("shipmentId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string ShipmentId { get; init; }

    /// <summary>
    /// Mode of shipment transportation. Possible values: <c>GROUND_SMALL_PARCEL</c>, <c>FREIGHT_LTL</c>, <c>FREIGHT_FTL_PALLET</c>, <c>FREIGHT_FTL_NONPALLET</c>, <c>OCEAN_LCL</c>, <c>OCEAN_FCL</c>, <c>AIR_SMALL_PARCEL</c>, <c>AIR_SMALL_PARCEL_EXPRESS</c>.
    /// </summary>
    [JsonPropertyName("shippingMode")]
    [StringLength(1024, MinimumLength = 1)]
    public required string ShippingMode { get; init; }

    /// <summary>
    /// Shipping program for the option. Possible values: <c>WALMART_PARTNERED_CARRIER</c>, <c>USE_YOUR_OWN_CARRIER</c>.
    /// </summary>
    [JsonPropertyName("shippingSolution")]
    [StringLength(1024, MinimumLength = 1)]
    public required string ShippingSolution { get; init; }

    /// <summary>
    /// Identifier of a transportation option.
    /// </summary>
    [JsonPropertyName("transportationOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string TransportationOptionId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
