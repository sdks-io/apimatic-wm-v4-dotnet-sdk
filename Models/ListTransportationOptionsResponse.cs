using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listTransportationOptions</c> response.
/// </summary>
public record ListTransportationOptionsResponse
{
    /// <summary>
    /// Transportation options generated for the placement option.
    /// </summary>
    [JsonPropertyName("transportationOptions")]
    public required IReadOnlyList<CommonTransportationOption> TransportationOptions { get; init; }

    /// <summary>
    /// Contains tokens to fetch from a certain page.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("pagination")]
    public CommonPagination? Pagination { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
