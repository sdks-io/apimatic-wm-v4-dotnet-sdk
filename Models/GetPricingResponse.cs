using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// The response schema for the getPricing and getCompetitivePricing operations.
/// </summary>
public record GetPricingResponse
{
    /// <summary>
    /// The payload for the getPricing and getCompetitivePricing operations.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("payload")]
    [MaxLength(20)]
    public IReadOnlyList<Price>? Payload { get; init; }

    /// <summary>
    /// A list of error responses returned when a request is unsuccessful.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("errors")]
    public IReadOnlyList<Error3>? Errors { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
