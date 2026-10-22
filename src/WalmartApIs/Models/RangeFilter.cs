using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record RangeFilter
{
    /// <summary>
    /// Start value for the filter range.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("from")]
    public string? From { get; init; }

    /// <summary>
    /// End value for the filter range.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("to")]
    public string? To { get; init; }

    /// <summary>
    /// The type of filter to apply.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("rowFilterType")]
    public required RowFilterType RowFilterType { get; init; }

    /// <summary>
    /// Specifies the column name to which the filter should be applied. Only certain columns in the report support this filter. Refer to the guide section for more details.
    /// <para>
    /// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("columnName")]
    public required string ColumnName { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
