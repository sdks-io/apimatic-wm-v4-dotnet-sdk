using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record UpdateShipmentStatusRequest
{
    /// <summary>
    /// Non-terminal shipment-lifecycle state. Mirrors Amazon SP-API
    /// Orders v0 <c>shipmentStatus</c>. For terminal <c>Delivered</c> use the
    /// dedicated <c>/deliver</c> endpoint.
    /// </summary>
    [JsonPropertyName("shipmentStatus")]
    public required ShipmentStatus1 ShipmentStatus { get; init; }

    /// <summary>
    /// ISO-8601 timestamp at which the seller observed the status
    /// change. Optional — if omitted, FMS defaults to server time.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("statusDate")]
    public DateTimeOffset? StatusDate { get; init; }

    [JsonPropertyName("orderLines")]
    [MinLength(1)]
    public required IReadOnlyList<UpdateShipmentStatusLine> OrderLines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
