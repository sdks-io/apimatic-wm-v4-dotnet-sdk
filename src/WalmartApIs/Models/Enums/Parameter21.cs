using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// To apply a range filter based on the predefined parameter. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
/// <para>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | PRICE | To filter based on the price. | string |
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter21>))]
public sealed record Parameter21 : OpenStringEnum<Parameter21>
{
    private Parameter21(string value) : base(value)
    {
    }

    public static readonly Parameter21 Price = new("PRICE");

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
