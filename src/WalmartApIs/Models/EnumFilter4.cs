using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// Filter based on preset parameters and their associated values is possible with EnumFilter.
/// No parameter should be repeated.
/// </summary>
public record EnumFilter4
{
    /// <summary>
    /// This attribute applies an enum filter based on the predefined parameter.
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ITEM_AVAILABILITY_STATUS | The filters shows if an item is new or existing at Walmart. | string |
    /// | DEMAND_SALES_TRENDS | The months of the year when demand is high for an item. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("parameter")]
    public Parameter16? Parameter { get; init; }

    /// <summary>
    /// Values correspond to the parameter used to apply filters to the response. The data in values[] are predefined. An OR operator is applied between multiple values.
    /// <para>
    /// | Attribute | Associated parameter of enumFilter | Description | Data Type |
    /// | --- | ----------- | ----------- | ------- |
    /// | EXISTING_IN_WALMART | ITEM_AVAILABILITY_STATUS | Filters items that already exist on Walmart. | string |
    /// | NEW_TO_WALMART | ITEM_AVAILABILITY_STATUS | Filters items that are new to Walmart. | string |
    /// | JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is expected for the recommended item. | string |
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("values")]
    public Values4? Values { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
