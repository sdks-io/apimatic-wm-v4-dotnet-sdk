using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter configuration to narrow down report results.
/// <para>
/// <b>Validation</b>: Both field and values are required when a filter is provided.
/// </para>
/// </summary>
public record WsrFilter
{
    /// <summary>
    /// Attribute on which filter needs to be applied.
    /// <para>
    /// <b>Supported fields</b>:
    /// - <c>campaignId</c>: Filter by campaign identifier(s)
    /// - <c>adGroupId</c>: Filter by ad group identifier(s)
    /// - <c>creativeId</c>: Filter by creative identifier(s)
    /// </para>
    /// </summary>
    [JsonPropertyName("field")]
    public required Field1 Field { get; init; }

    /// <summary>
    /// List of attribute values to filter on.
    /// Multiple values act as an OR condition.
    /// </summary>
    [JsonPropertyName("values")]
    [MinLength(1)]
    public required IReadOnlyList<string> Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
