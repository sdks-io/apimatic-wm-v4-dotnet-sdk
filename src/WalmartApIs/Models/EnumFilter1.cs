using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter based on preset parameters and their associated values is possible with EnumFilter.
/// No parameter should be repeated.
/// </summary>
public record EnumFilter1
{
    /// <summary>
    /// To apply an enum filter based on the predefined parameter.
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ITEM_AVAILABILITY_STATUS | To filter based on whether the items which are new to Walmart or existing in Walmart. | string |
    /// | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("parameter")]
    public Parameter4? Parameter { get; init; }

    /// <summary>
    /// Values correspond to the parameter for applying filter on the response. The data in values[] are predefined. OR operator is used between the values.
    /// <para>
    /// | Attribute | Associated parameter of enumFilter | Description | Data Type |
    /// | --- | ----------- | ----------- | ------- |
    /// | EXISTING_IN_WALMART | ITEM_AVAILABILITY_STATUS | Filters existing items at Walmart. | string |
    /// | NEW_TO_WALMART | ITEM_AVAILABILITY_STATUS | Filters new items at Walmart. | string |
    /// | JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public Values1? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
