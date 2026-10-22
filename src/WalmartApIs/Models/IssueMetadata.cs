using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Static metadata for an issue type. Provides human-readable information
/// for building diagnostic UIs including issue name, description, severity,
/// remediability, and help links.
/// <para>
/// This metadata is the same for every item — it describes the issue type itself,
/// not a specific occurrence on an item.
/// </para>
/// </summary>
public record IssueMetadata
{
    /// <summary>
    /// Human-readable issue name for UI short headline display.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueName")]
    public string? IssueName { get; init; }

    /// <summary>
    /// Issue severity category.
    /// <list type="bullet">
    ///   <item><description><b>BLOCKED</b>: Item cannot be advertised</description></item>
    ///   <item><description><b>LIMITED</b>: Item has reduced visibility or performance</description></item>
    ///   <item><description><b>NO_ISSUES</b>: Item has no SEM eligibility issues</description></item>
    /// </list>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueCategory")]
    public IssueCategory1? IssueCategory { get; init; }

    /// <summary>
    /// Whether the partner can remediate this issue.
    /// <c>true</c> = actionable by partner (show "Fix Now" UI affordance),
    /// <c>false</c> = requires Walmart or system intervention (informational only).
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("isFixable")]
    public bool? IsFixable { get; init; }

    /// <summary>
    /// Human-readable description of the issue with remediation guidance.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("issueDescription")]
    public string? IssueDescription { get; init; }

    /// <summary>
    /// Help link (Walmart-hosted or Google support) for additional information.
    /// May be null if no help link is available for this issue type.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("learnMoreUrl")]
    public string? LearnMoreUrl { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
