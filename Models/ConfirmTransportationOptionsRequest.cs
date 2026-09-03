using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>confirmTransportationOptions</c> request.
/// </summary>
public record ConfirmTransportationOptionsRequest
{
    /// <summary>
    /// Information needed to confirm one of the available transportation options.
    /// </summary>
    [JsonPropertyName("transportationSelections")]
    [MinLength(1)]
    public required IReadOnlyList<CommonTransportationSelection> TransportationSelections { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
