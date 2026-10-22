using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// To apply a range filter based on the predefined parameter.
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | PRICE | To filter based on the price. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter2>))]
public sealed record Parameter2 : OpenStringEnum<Parameter2>
{
    private Parameter2(string value) : base(value)
    {
    }

    public static readonly Parameter2 Price = new("PRICE");

    public TResult Match<TResult>(Func<TResult> onPrice, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Price => onPrice(),
            _ => otherwise(Value)
        };

    public void Match(Action onPrice, Action<string> otherwise)
    {
        if (this == Price) onPrice();
        else otherwise(Value);
    }
}
