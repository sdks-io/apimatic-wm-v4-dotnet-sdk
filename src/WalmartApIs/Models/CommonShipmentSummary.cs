using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Summary information about a shipment.
/// </summary>
public record CommonShipmentSummary
{
    /// <summary>
    /// Identifier of a shipment. A shipment contains the boxes and units being inbounded.
    /// </summary>
    [JsonPropertyName("shipmentId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string ShipmentId { get; init; }

    /// <summary>
    /// The status of a shipment. Possible values: <c>ABANDONED</c>, <c>CANCELLED</c>, <c>CHECKED_IN</c>, <c>CLOSED</c>, <c>DELETED</c>, <c>DELIVERED</c>, <c>IN_TRANSIT</c>, <c>MIXED</c>, <c>READY_TO_SHIP</c>, <c>RECEIVING</c>, <c>SHIPPED</c>, <c>UNCONFIRMED</c>, <c>WORKING</c>.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
