using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter based on preset parameters and their associated values is possible with EnumFilter.
/// No parameter should be repeated. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt;
/// </summary>
public record EnumFilter5
{
    /// <summary>
    /// Used to apply an enum filter based on a predefined parameter.
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ITEM_AVAILABILITY_STATUS | Filters items based on whether they are new to Walmart or already exist on Walmart. | string |
    /// | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("parameter")]
    public Parameter20? Parameter { get; init; }

    /// <summary>
    /// Values correspond to the parameter used to apply filters to the response. The data in values[] are predefined. An OR operator is used between the values.
    /// <para>
    /// | Attribute | Associated parameter of enumFilter | Description | Data Type |
    /// | --- | --- | --- | --- |
    /// | EXISTING_IN_WALMART | ITEM_AVAILABILITY_STATUS | Filters items that already exist on Walmart. | string |
    /// | NEW_TO_WALMART | ITEM_AVAILABILITY_STATUS | Filters items that are new to Walmart. | string |
    /// | JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public Values5? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
