using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// GetInboundOperationStatus response.
/// </summary>
public record CommonInboundOperationStatus
{
    /// <summary>
    /// The name of the operation in the asynchronous API call.
    /// </summary>
    [JsonPropertyName("operation")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Operation { get; init; }

    /// <summary>
    /// The operation ID returned by the asynchronous API call.
    /// </summary>
    [JsonPropertyName("operationId")]
    [StringLength(38, MinimumLength = 36)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string OperationId { get; init; }

    /// <summary>
    /// The problems in the processing of the asynchronous operation.
    /// </summary>
    [JsonPropertyName("operationProblems")]
    public required IReadOnlyList<CommonOperationProblem> OperationProblems { get; init; }

    /// <summary>
    /// The status of an operation.
    /// </summary>
    [JsonPropertyName("operationStatus")]
    public required CommonOperationStatus OperationStatus { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
