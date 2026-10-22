using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Sort configuration for ordering the report results.
/// <para>
/// <b>Defaults</b>: field="gmv", order="DESC"
/// </para>
/// </summary>
public record WsrSort
{
    /// <summary>
    /// Attribute on which sorting needs to be performed.
    /// <para>
    /// <b>Supported Values</b>: clicks, gmv, orders
    /// <b>Default</b>: gmv
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("field")]
    public Field? Field { get; init; } = Field.Gmv;

    /// <summary>
    /// Sorting order.
    /// <para>
    /// <b>Default</b>: DESC
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("order")]
    public Order? Order { get; init; } = Order.Desc;

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
