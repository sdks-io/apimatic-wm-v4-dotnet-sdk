using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The <c>createInboundPlan</c> response.
/// </summary>
public record CreateInboundPlanResponse
{
    /// <summary>
    /// Identifier of the newly created inbound plan.
    /// </summary>
    [JsonPropertyName("inboundPlanId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// UUID for the given operation.
    /// </summary>
    [JsonPropertyName("operationId")]
    [StringLength(38, MinimumLength = 36)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string OperationId { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
