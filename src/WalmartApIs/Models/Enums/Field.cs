using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Attribute on which sorting needs to be performed.
/// <para>
/// <b>Supported Values</b>: clicks, gmv, orders
/// <b>Default</b>: gmv
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field>))]
public sealed record Field : OpenStringEnum<Field>
{
    private Field(string value) : base(value)
    {
    }

    public static readonly Field Clicks = new("clicks");

    public static readonly Field Gmv = new("gmv");

    public static readonly Field Orders = new("orders");

    public TResult Match<TResult>(Func<TResult> onClicks,
        Func<TResult> onGmv,
        Func<TResult> onOrders,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Clicks => onClicks(),
            _ when this == Gmv => onGmv(),
            _ when this == Orders => onOrders(),
            _ => otherwise(Value)
        };

    public void Match(Action onClicks, Action onGmv, Action onOrders, Action<string> otherwise)
    {
        if (this == Clicks) onClicks();
        else if (this == Gmv) onGmv();
        else if (this == Orders) onOrders();
        else otherwise(Value);
    }
}
