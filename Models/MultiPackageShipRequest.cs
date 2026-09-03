using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record MultiPackageShipRequest
{
    [JsonPropertyName("packages")]
    [MinLength(1)]
    public required IReadOnlyList<ShipPackage> Packages { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
