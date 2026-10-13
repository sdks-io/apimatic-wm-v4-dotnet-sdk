using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type11>))]
public sealed record Type11 : OpenStringEnum<Type11>
{
    private Type11(string value) : base(value)
    {
    }

    public static readonly Type11 Pickup = new("PICKUP");

    public static readonly Type11 Dropoff = new("DROPOFF");

    public TResult Match<TResult>(Func<TResult> onPickup, Func<TResult> onDropoff, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pickup => onPickup(),
            _ when this == Dropoff => onDropoff(),
            _ => otherwise(Value)
        };

    public void Match(Action onPickup, Action onDropoff, Action<string> otherwise)
    {
        if (this == Pickup) onPickup();
        else if (this == Dropoff) onDropoff();
        else otherwise(Value);
    }
}
