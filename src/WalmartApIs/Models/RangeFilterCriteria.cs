using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter based on a range with RangeFilter. You must also pass a parameter along with any of the beginning or the ending points or both.
/// No parameter should be repeated.
/// </summary>
public record RangeFilterCriteria
{
    /// <summary>
    /// To apply a range filter based on the predefined parameter.
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | PRICE | To filter based on the price. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("parameter")]
    public Parameter2? Parameter { get; init; }

    /// <summary>
    /// Filter range start
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("from")]
    public string? From { get; init; }

    /// <summary>
    /// Filter range end
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("to")]
    public string? To { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
