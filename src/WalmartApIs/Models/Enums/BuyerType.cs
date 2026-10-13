using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<BuyerType>))]
public sealed record BuyerType : OpenStringEnum<BuyerType>
{
    private BuyerType(string value) : base(value)
    {
    }

    public static readonly BuyerType B2B = new("B2B");

    public static readonly BuyerType B2C = new("B2C");

    public static readonly BuyerType All = new("All");

    public TResult Match<TResult>(Func<TResult> onB2B,
        Func<TResult> onB2C,
        Func<TResult> onAll,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == B2B => onB2B(),
            _ when this == B2C => onB2C(),
            _ when this == All => onAll(),
            _ => otherwise(Value)
        };

    public void Match(Action onB2B, Action onB2C, Action onAll, Action<string> otherwise)
    {
        if (this == B2B) onB2B();
        else if (this == B2C) onB2C();
        else if (this == All) onAll();
        else otherwise(Value);
    }
}
