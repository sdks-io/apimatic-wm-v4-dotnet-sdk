using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<RebateType>))]
public sealed record RebateType : OpenStringEnum<RebateType>
{
    private RebateType(string value) : base(value)
    {
    }

    public static readonly RebateType Amount = new("AMOUNT");

    public static readonly RebateType Product = new("PRODUCT");

    public TResult Match<TResult>(Func<TResult> onAmount, Func<TResult> onProduct, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Amount => onAmount(),
            _ when this == Product => onProduct(),
            _ => otherwise(Value)
        };

    public void Match(Action onAmount, Action onProduct, Action<string> otherwise)
    {
        if (this == Amount) onAmount();
        else if (this == Product) onProduct();
        else otherwise(Value);
    }
}
