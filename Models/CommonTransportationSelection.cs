using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The transportation option selected to confirm.
/// </summary>
public record CommonTransportationSelection
{
    /// <summary>
    /// The seller's contact information.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("contactInformation")]
    public CommonContactInformation? ContactInformation { get; init; }

    /// <summary>
    /// Shipment ID that the transportation option is for.
    /// </summary>
    [JsonPropertyName("shipmentId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string ShipmentId { get; init; }

    /// <summary>
    /// Transportation option being selected for the provided shipment.
    /// </summary>
    [JsonPropertyName("transportationOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string TransportationOptionId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
