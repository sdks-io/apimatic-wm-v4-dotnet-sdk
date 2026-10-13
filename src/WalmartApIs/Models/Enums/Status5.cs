using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status5>))]
public sealed record Status5 : OpenStringEnum<Status5>
{
    private Status5(string value) : base(value)
    {
    }

    public static readonly Status5 PreTransit = new("PRE_TRANSIT");

    public static readonly Status5 InTransit = new("IN_TRANSIT");

    public static readonly Status5 OutForDelivery = new("OUT_FOR_DELIVERY");

    public static readonly Status5 Delivered = new("DELIVERED");

    public static readonly Status5 Exception = new("EXCEPTION");

    public static readonly Status5 Returned = new("RETURNED");

    public static readonly Status5 Unknown = new("UNKNOWN");

    public TResult Match<TResult>(Func<TResult> onPreTransit,
        Func<TResult> onInTransit,
        Func<TResult> onOutForDelivery,
        Func<TResult> onDelivered,
        Func<TResult> onException,
        Func<TResult> onReturned,
        Func<TResult> onUnknown,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == PreTransit => onPreTransit(),
            _ when this == InTransit => onInTransit(),
            _ when this == OutForDelivery => onOutForDelivery(),
            _ when this == Delivered => onDelivered(),
            _ when this == Exception => onException(),
            _ when this == Returned => onReturned(),
            _ when this == Unknown => onUnknown(),
            _ => otherwise(Value)
        };

    public void Match(Action onPreTransit,
        Action onInTransit,
        Action onOutForDelivery,
        Action onDelivered,
        Action onException,
        Action onReturned,
        Action onUnknown,
        Action<string> otherwise)
    {
        if (this == PreTransit) onPreTransit();
        else if (this == InTransit) onInTransit();
        else if (this == OutForDelivery) onOutForDelivery();
        else if (this == Delivered) onDelivered();
        else if (this == Exception) onException();
        else if (this == Returned) onReturned();
        else if (this == Unknown) onUnknown();
        else otherwise(Value);
    }
}
