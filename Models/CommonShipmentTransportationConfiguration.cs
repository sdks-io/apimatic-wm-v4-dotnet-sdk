using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Details needed to generate the transportation options.
/// </summary>
public record CommonShipmentTransportationConfiguration
{
    /// <summary>
    /// The seller's contact information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contactInformation")]
    public CommonContactInformation? ContactInformation { get; init; }

    /// <summary>
    /// Freight information describes the SKUs that are in transit.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("freightInformation")]
    public CommonFreightInformation? FreightInformation { get; init; }

    /// <summary>
    /// List of pallet configuration inputs.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pallets")]
    public IReadOnlyList<CommonPalletInput>? Pallets { get; init; }

    /// <summary>
    /// Contains only a starting DateTime.
    /// </summary>
    [JsonPropertyName("readyToShipWindow")]
    public required CommonWindowInput ReadyToShipWindow { get; init; }

    /// <summary>
    /// Identifier of a shipment.
    /// </summary>
    [JsonPropertyName("shipmentId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string ShipmentId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
