using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Validation.Attributes;

namespace WalmartApIs.Models;

public record V3FeedsRequest1
{
    /// <summary>
    /// ProgramAction feed header details.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ProgramActionFeedHeader")]
    public ProgramActionFeedHeader11? ProgramActionFeedHeader { get; init; }

    /// <summary>
    /// This includes all the SKU IDs and the type of shipping configuration to migrate.
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("ProgramAction")]
    [UniqueItems]
    public IReadOnlyList<ProgramAction11>? ProgramAction { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
