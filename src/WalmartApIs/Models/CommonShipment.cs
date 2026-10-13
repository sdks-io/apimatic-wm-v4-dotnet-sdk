using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information pertaining to a shipment in an inbound plan.
/// </summary>
public record CommonShipment
{
    /// <summary>
    /// The seller's contact information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contactInformation")]
    public CommonContactInformation? ContactInformation { get; init; }

    /// <summary>
    /// Specifies the date that the seller expects their shipment will be shipped.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dates")]
    public CommonDates? Dates { get; init; }

    /// <summary>
    /// The Walmart Ship Node address and warehouse ID.
    /// </summary>
    [JsonPropertyName("destination")]
    public required CommonShipmentDestination Destination { get; init; }

    /// <summary>
    /// Freight information describes the SKUs that are in transit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("freightInformation")]
    public CommonFreightInformation? FreightInformation { get; init; }

    /// <summary>
    /// The name of the shipment.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The identifier of a placement option.
    /// </summary>
    [JsonPropertyName("placementOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PlacementOptionId { get; init; }

    /// <summary>
    /// Selected delivery window attributes.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("selectedDeliveryWindow")]
    public CommonSelectedDeliveryWindow? SelectedDeliveryWindow { get; init; }

    /// <summary>
    /// Identifier of a transportation option.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("selectedTransportationOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public string? SelectedTransportationOptionId { get; init; }

    /// <summary>
    /// List of self ship appointment details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("selfShipAppointmentDetails")]
    public IReadOnlyList<CommonSelfShipAppointmentDetails>? SelfShipAppointmentDetails { get; init; }

    /// <summary>
    /// The confirmed shipment ID which shows up on labels.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipmentConfirmationId")]
    [StringLength(1024, MinimumLength = 1)]
    public string? ShipmentConfirmationId { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    [JsonPropertyName("shipmentId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string ShipmentId { get; init; }

    /// <summary>
    /// Specifies the 'ship from' address for the shipment.
    /// </summary>
    [JsonPropertyName("source")]
    public required CommonShipmentSource Source { get; init; }

    /// <summary>
    /// The status of a shipment. Possible values: <c>ABANDONED</c>, <c>CANCELLED</c>, <c>CHECKED_IN</c>, <c>CLOSED</c>, <c>DELETED</c>, <c>DELIVERED</c>, <c>IN_TRANSIT</c>, <c>MIXED</c>, <c>READY_TO_SHIP</c>, <c>RECEIVING</c>, <c>SHIPPED</c>, <c>UNCONFIRMED</c>, <c>WORKING</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public string? Status { get; init; }

    /// <summary>
    /// Tracking information for LTL and SPD shipments.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("trackingDetails")]
    public CommonTrackingDetails? TrackingDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
