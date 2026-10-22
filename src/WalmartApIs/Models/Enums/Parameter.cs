using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Used to apply an enum filter based on a predefined parameter.
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | --- | --- |
/// | ITEM_AVAILABILITY_STATUS | Filters items based on whether they are new to Walmart or already exist on Walmart. | string |
/// | DEMAND_SALES_TRENDS | Indicates the months of the year when high demand is observed for the recommended item. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter>))]
public sealed record Parameter : OpenStringEnum<Parameter>
{
    private Parameter(string value) : base(value)
    {
    }

    public static readonly Parameter ItemAvailabilityStatus = new("ITEM_AVAILABILITY_STATUS");

    public static readonly Parameter DemandSalesTrends = new("DEMAND_SALES_TRENDS");

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
