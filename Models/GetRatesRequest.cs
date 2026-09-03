using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record GetRatesRequest
{
    [JsonPropertyName("shipTo")]
    public required Address1 ShipTo { get; init; }

    [JsonPropertyName("shipFrom")]
    public required Address1 ShipFrom { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("returnTo")]
    public Address1? ReturnTo { get; init; }

    /// <summary>
    /// When the shipment will be tendered to the carrier.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("shipDate")]
    public DateTimeOffset? ShipDate { get; init; }

    [JsonPropertyName("packages")]
    [MinLength(1)]
    public required IReadOnlyList<Package> Packages { get; init; }

    [JsonPropertyName("channelDetails")]
    public required ChannelDetails ChannelDetails { get; init; }

    /// <summary>
    /// Optional seller-supplied filter to restrict the rate quote to
    /// a specific carrier(s) and/or service(s).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("serviceSelection")]
    public ServiceSelection? ServiceSelection { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("valueAddedServices")]
    public IReadOnlyList<RequestedValueAddedService>? ValueAddedServices { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
