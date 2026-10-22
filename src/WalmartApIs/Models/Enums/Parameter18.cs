using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | BRAND &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;| To filter based on list of brands which are associated with the assortment recommendations. This is allowed when the categorization type is CATEGORY | string |
/// | CATEGORY &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt; | To filter based on list of categories which are associated with the assortment recommendations. This is allowed when the categorization type is BRAND | string |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Parameter18>))]
public sealed record Parameter18 : OpenStringEnum<Parameter18>
{
    private Parameter18(string value) : base(value)
    {
    }

    public static readonly Parameter18 Category = new("CATEGORY");

    public static readonly Parameter18 Brand = new("BRAND");

    public TResult Match<TResult>(Func<TResult> onCategory, Func<TResult> onBrand, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Category => onCategory(),
            _ when this == Brand => onBrand(),
            _ => otherwise(Value)
        };

    public void Match(Action onCategory, Action onBrand, Action<string> otherwise)
    {
        if (this == Category) onCategory();
        else if (this == Brand) onBrand();
        else otherwise(Value);
    }
}
