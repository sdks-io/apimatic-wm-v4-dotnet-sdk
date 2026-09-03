using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Contains information pertaining to the placement of the contents of an inbound plan and the related costs.
/// </summary>
public record CommonPlacementOption
{
    /// <summary>
    /// Discount for the offered option.
    /// </summary>
    [JsonPropertyName("discounts")]
    public required IReadOnlyList<CommonIncentive> Discounts { get; init; }

    /// <summary>
    /// The expiration date of the placement option. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mm:ss.sssZ</c>.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("expiration")]
    public DateTimeOffset? Expiration { get; init; }

    /// <summary>
    /// The fee for the offered option.
    /// </summary>
    [JsonPropertyName("fees")]
    public required IReadOnlyList<CommonIncentive> Fees { get; init; }

    /// <summary>
    /// The identifier of a placement option. A placement option represents the shipment splits and destinations of SKUs.
    /// </summary>
    [JsonPropertyName("placementOptionId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string PlacementOptionId { get; init; }

    /// <summary>
    /// Shipment IDs.
    /// </summary>
    [JsonPropertyName("shipmentIds")]
    public required IReadOnlyList<string> ShipmentIds { get; init; }

    /// <summary>
    /// The status of a placement option. Possible values: <c>OFFERED</c>, <c>ACCEPTED</c>, <c>EXPIRED</c>.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
