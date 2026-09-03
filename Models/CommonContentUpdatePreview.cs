using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Preview of the changes that will be applied to the shipment.
/// </summary>
public record CommonContentUpdatePreview
{
    /// <summary>
    /// Identifier of a content update preview.
    /// </summary>
    [JsonPropertyName("contentUpdatePreviewId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string ContentUpdatePreviewId { get; init; }

    /// <summary>
    /// The time at which the content update expires. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mm:ss.sssZ</c>.
    /// </summary>
    [JsonPropertyName("expiration")]
    public required DateTimeOffset Expiration { get; init; }

    /// <summary>
    /// Objects that were included in the update request.
    /// </summary>
    [JsonPropertyName("requestedUpdates")]
    public required CommonRequestedUpdates RequestedUpdates { get; init; }

    /// <summary>
    /// Contains information pertaining to a transportation option and the related carrier.
    /// </summary>
    [JsonPropertyName("transportationOption")]
    public required CommonTransportationOption TransportationOption { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
