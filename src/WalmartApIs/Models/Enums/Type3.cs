using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Type3>))]
public sealed record Type3 : OpenStringEnum<Type3>
{
    private Type3(string value) : base(value)
    {
    }

    public static readonly Type3 Brand = new("brand");

    public static readonly Type3 Category = new("category");

    public TResult Match<TResult>(Func<TResult> onBrand, Func<TResult> onCategory, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Brand => onBrand(),
            _ when this == Category => onCategory(),
            _ => otherwise(Value)
        };

    public void Match(Action onBrand, Action onCategory, Action<string> otherwise)
    {
        if (this == Brand) onBrand();
        else if (this == Category) onCategory();
        else otherwise(Value);
    }
}
