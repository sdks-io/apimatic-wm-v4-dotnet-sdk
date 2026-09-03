using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ShipPackage
{
    /// <summary>
    /// Caller-supplied stable identifier for this physical package.
    /// Optional — server falls back to the package's tracking
    /// number when echoed in the response.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packageId")]
    public string? PackageId { get; init; }

    [JsonPropertyName("trackingInfo")]
    public required TrackingInfo TrackingInfo { get; init; }

    /// <summary>
    /// Physical dimensions of a shipped package. All numeric values are
    /// non-negative; unit enums avoid the unit-ambiguity bug that bit
    /// gmp-orders-mono PayloadUtil pre-2024.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dimensions")]
    public PackageDimensions1? Dimensions { get; init; }

    [JsonPropertyName("lines")]
    [MinLength(1)]
    public required IReadOnlyList<ShipPackageLine> Lines { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
