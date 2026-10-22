using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | BRAND | To get list of brands which are associated with the assortment recommendations | string |
/// | CATEGORY | To get list of categories which are associated with the assortment recommendations | string |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CategorizationType>))]
public sealed record CategorizationType : OpenStringEnum<CategorizationType>
{
    private CategorizationType(string value) : base(value)
    {
    }

    public static readonly CategorizationType Brand = new("BRAND");

    public static readonly CategorizationType Category = new("CATEGORY");

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
