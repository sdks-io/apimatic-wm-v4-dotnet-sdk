using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: Global&lt;/b&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RebateType3>))]
public sealed record RebateType3 : OpenStringEnum<RebateType3>
{
    private RebateType3(string value) : base(value)
    {
    }

    public static readonly RebateType3 Amount = new("AMOUNT");

    public static readonly RebateType3 Product = new("PRODUCT");

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
