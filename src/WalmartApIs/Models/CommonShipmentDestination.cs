using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The Walmart Ship Node address and warehouse ID.
/// </summary>
public record CommonShipmentDestination
{
    /// <summary>
    /// Specific details to identify a place.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("address")]
    public CommonAddress? Address { get; init; }

    /// <summary>
    /// The type of destination for this shipment. Possible values: <c>WALMART_OPTIMIZED</c>, <c>WALMART_SHIP_NODE</c>.
    /// </summary>
    [JsonPropertyName("destinationType")]
    [StringLength(1024, MinimumLength = 1)]
    public required string DestinationType { get; init; }

    /// <summary>
    /// The Ship Node that the shipment should be sent to. This can be empty if the destination type is <c>WALMART_OPTIMIZED</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("warehouseId")]
    [StringLength(1024, MinimumLength = 1)]
    public string? WarehouseId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
