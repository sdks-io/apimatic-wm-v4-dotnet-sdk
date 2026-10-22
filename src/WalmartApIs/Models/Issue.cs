using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Issue affecting an item. Contains the issue type identifier only.
/// <para>
/// The <c>issueType</c> serves as a lookup key into the issue metadata returned by the
/// <c>GET /item-issues/issue-types</c> reference endpoint. All static metadata (name, description,
/// category, fixability, help links) lives in that endpoint's response.
/// </para>
/// </summary>
public record Issue
{
    /// <summary>
    /// Lookup key into the issue metadata returned by the <c>GET /item-issues/issue-types</c> endpoint. Maps to one of the supported issue type enum values.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueType")]
    public IssueType? IssueType { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
