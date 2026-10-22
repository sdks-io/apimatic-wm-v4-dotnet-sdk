using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Object describing a single uploaded document.
/// </summary>
public record DocumentType1
{
    /// <summary>
    /// Original file name for the uploaded document.
    /// </summary>
    [JsonPropertyName("fileName")]
    public required string FileName { get; init; }

    /// <summary>
    /// Document category; one of PROOF_OF_DAMAGED_ITEM, INVOICE, OTHER, PPOD.
    /// </summary>
    [JsonPropertyName("type")]
    public required Type11 Type { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
