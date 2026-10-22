using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// To apply an enum filter based on the predefined parameter.
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ITEM_AVAILABILITY_STATUS | To filter based on whether the items which are new to Walmart or existing in Walmart. | string |
/// | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter4>))]
public sealed record Parameter4 : OpenStringEnum<Parameter4>
{
    private Parameter4(string value) : base(value)
    {
    }

    public static readonly Parameter4 ItemAvailabilityStatus = new("ITEM_AVAILABILITY_STATUS");

    public static readonly Parameter4 DemandSalesTrends = new("DEMAND_SALES_TRENDS");

    public TResult Match<TResult>(Func<TResult> onItemAvailabilityStatus,
        Func<TResult> onDemandSalesTrends,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ItemAvailabilityStatus => onItemAvailabilityStatus(),
            _ when this == DemandSalesTrends => onDemandSalesTrends(),
            _ => otherwise(Value)
        };

    public void Match(Action onItemAvailabilityStatus, Action onDemandSalesTrends, Action<string> otherwise)
    {
        if (this == ItemAvailabilityStatus) onItemAvailabilityStatus();
        else if (this == DemandSalesTrends) onDemandSalesTrends();
        else otherwise(Value);
    }
}
