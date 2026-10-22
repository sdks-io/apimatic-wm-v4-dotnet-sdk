using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | BRAND | To filter based on list of brands which are associated with the assortment recommendations | string |
/// | CATEGORY | To filter based on list of categories which are associated with the assortment recommendations | string |
/// | PRODUCT_TYPE | To filter based on list of product types which are associated with the assortment recommendations | string |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter1>))]
public sealed record Parameter1 : OpenStringEnum<Parameter1>
{
    private Parameter1(string value) : base(value)
    {
    }

    public static readonly Parameter1 Brand = new("BRAND");

    public static readonly Parameter1 Category = new("CATEGORY");

    public static readonly Parameter1 ProductType = new("PRODUCT_TYPE");

    public TResult Match<TResult>(Func<TResult> onBrand,
        Func<TResult> onCategory,
        Func<TResult> onProductType,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Brand => onBrand(),
            _ when this == Category => onCategory(),
            _ when this == ProductType => onProductType(),
            _ => otherwise(Value)
        };

    public void Match(Action onBrand, Action onCategory, Action onProductType, Action<string> otherwise)
    {
        if (this == Brand) onBrand();
        else if (this == Category) onCategory();
        else if (this == ProductType) onProductType();
        else otherwise(Value);
    }
}
