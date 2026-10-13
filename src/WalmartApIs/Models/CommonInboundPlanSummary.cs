using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// A light-weight inbound plan.
/// </summary>
public record CommonInboundPlanSummary
{
    /// <summary>
    /// The time at which the inbound plan was created. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mm:ssZ</c>.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Identifier of an inbound plan.
    /// </summary>
    [JsonPropertyName("inboundPlanId")]
    [StringLength(38, MinimumLength = 38)]
    [RegularExpression("^[a-zA-Z0-9-]*$")]
    public required string InboundPlanId { get; init; }

    /// <summary>
    /// The time at which the inbound plan was last updated. In ISO 8601 datetime format with pattern <c>yyyy-MM-ddTHH:mm:ssZ</c>.
    /// </summary>
    [JsonPropertyName("lastUpdatedAt")]
    public required DateTimeOffset LastUpdatedAt { get; init; }

    /// <summary>
    /// A list of Walmart marketplace IDs associated with this inbound plan.
    /// </summary>
    [JsonPropertyName("marketplaceIds")]
    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    /// <summary>
    /// Human-readable name of the inbound plan.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Specific details to identify a place.
    /// </summary>
    [JsonPropertyName("sourceAddress")]
    public required CommonAddress SourceAddress { get; init; }

    /// <summary>
    /// The current status of the inbound plan. Possible values: <c>ACTIVE</c>, <c>VOIDED</c>, <c>SHIPPED</c>, <c>ERRORED</c>.
    /// </summary>
    [JsonPropertyName("status")]
    [StringLength(1024, MinimumLength = 1)]
    public required string Status { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
