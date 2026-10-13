using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>updateInboundPlanName</c> request.
/// </summary>
public record UpdateInboundPlanNameRequest
{
    /// <summary>
    /// A human-readable name to update the inbound plan name to.
    /// </summary>
    [JsonPropertyName("name")]
    [StringLength(40, MinimumLength = 1)]
    public required string Name { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
