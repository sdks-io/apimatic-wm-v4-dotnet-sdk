using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status>))]
public sealed record Status : OpenStringEnum<Status>
{
    private Status(string value) : base(value)
    {
    }

    public static readonly Status Buyable = new("BUYABLE");

    public static readonly Status Suppressed = new("SUPPRESSED");

    public static readonly Status Discoverable = new("DISCOVERABLE");

    public TResult Match<TResult>(Func<TResult> onBuyable,
        Func<TResult> onSuppressed,
        Func<TResult> onDiscoverable,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Buyable => onBuyable(),
            _ when this == Suppressed => onSuppressed(),
            _ when this == Discoverable => onDiscoverable(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuyable, Action onSuppressed, Action onDiscoverable, Action<string> otherwise)
    {
        if (this == Buyable) onBuyable();
        else if (this == Suppressed) onSuppressed();
        else if (this == Discoverable) onDiscoverable();
        else otherwise(Value);
    }
}
