using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>generateTransportationOptions</c> request.
/// </summary>
public record GenerateTransportationOptionsRequest
{
    /// <summary>
    /// The placement option to generate transportation options for.
    /// </summary>
    [JsonPropertyName("placementOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PlacementOptionId { get; init; }

    /// <summary>
    /// List of shipment transportation configurations.
    /// </summary>
    [JsonPropertyName("shipmentTransportationConfigurations")]
    [MinLength(1)]
    public required IReadOnlyList<CommonShipmentTransportationConfiguration> ShipmentTransportationConfigurations { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
