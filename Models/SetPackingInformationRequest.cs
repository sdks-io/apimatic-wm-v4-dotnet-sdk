using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>setPackingInformation</c> request.
/// </summary>
public record SetPackingInformationRequest
{
    /// <summary>
    /// List of packing information for the inbound plan.
    /// </summary>
    [JsonPropertyName("packageGroupings")]
    [MinLength(1)]
    public required IReadOnlyList<CommonPackageGroupingInput> PackageGroupings { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
