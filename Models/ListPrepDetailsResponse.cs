using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listPrepDetails</c> response.
/// </summary>
public record ListPrepDetailsResponse
{
    /// <summary>
    /// A list of MSKUs and related prep details.
    /// </summary>
    [JsonPropertyName("mskuPrepDetails")]
    public required IReadOnlyList<CommonMskuPrepDetail> MskuPrepDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
