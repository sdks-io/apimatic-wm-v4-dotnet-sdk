using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>listItemComplianceDetails</c> response.
/// </summary>
public record ListItemComplianceDetailsResponse
{
    /// <summary>
    /// List of compliance details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("complianceDetails")]
    public IReadOnlyList<CommonComplianceDetail>? ComplianceDetails { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
