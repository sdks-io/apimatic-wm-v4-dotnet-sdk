using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// This attribute applies an enum filter based on the predefined parameter.
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ITEM_AVAILABILITY_STATUS | The filters shows if an item is new or existing at Walmart. | string |
/// | DEMAND_SALES_TRENDS | The months of the year when demand is high for an item. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter16>))]
public sealed record Parameter16 : OpenStringEnum<Parameter16>
{
    private Parameter16(string value) : base(value)
    {
    }

    public static readonly Parameter16 ItemAvailabilityStatus = new("ITEM_AVAILABILITY_STATUS");

    public static readonly Parameter16 DemandSalesTrends = new("DEMAND_SALES_TRENDS");

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
