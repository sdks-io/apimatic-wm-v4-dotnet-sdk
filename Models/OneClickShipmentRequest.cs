using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record OneClickShipmentRequest
{
    [JsonPropertyName("shipTo")]
    public required Address1 ShipTo { get; init; }

    [JsonPropertyName("shipFrom")]
    public required Address1 ShipFrom { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnTo")]
    public Address1? ReturnTo { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipDate")]
    public DateTimeOffset? ShipDate { get; init; }

    [JsonPropertyName("packages")]
    [MinLength(1)]
    public required IReadOnlyList<Package> Packages { get; init; }

    /// <summary>
    /// Optional seller-supplied filter to restrict the rate quote to
    /// a specific carrier(s) and/or service(s).
    /// </summary>
    [JsonPropertyName("serviceSelection")]
    public required ServiceSelection ServiceSelection { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("valueAddedServices")]
    public IReadOnlyList<RequestedValueAddedService>? ValueAddedServices { get; init; }

    [JsonPropertyName("requestedDocumentSpecification")]
    public required RequestedDocumentSpecification RequestedDocumentSpecification { get; init; }

    [JsonPropertyName("channelDetails")]
    public required ChannelDetails ChannelDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
