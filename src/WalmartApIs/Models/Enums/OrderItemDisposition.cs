using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<OrderItemDisposition>))]
public sealed record OrderItemDisposition : OpenStringEnum<OrderItemDisposition>
{
    private OrderItemDisposition(string value) : base(value)
    {
    }

    public static readonly OrderItemDisposition Sellable = new("Sellable");

    public static readonly OrderItemDisposition Unsellable = new("Unsellable");

    public TResult Match<TResult>(Func<TResult> onSellable,
        Func<TResult> onUnsellable,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Sellable => onSellable(),
            _ when this == Unsellable => onUnsellable(),
            _ => otherwise(Value)
        };

    public void Match(Action onSellable, Action onUnsellable, Action<string> otherwise)
    {
        if (this == Sellable) onSellable();
        else if (this == Unsellable) onUnsellable();
        else otherwise(Value);
    }
}
