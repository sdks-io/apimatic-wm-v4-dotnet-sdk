using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The type of page this template is for (For example, <c>ITEM</c>, <c>BRANDSHOP</c>).
/// <para>
/// &lt;span style="color:green"&gt;<b>Market availability: Global</b>&lt;/span&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PageType>))]
public sealed record PageType : OpenStringEnum<PageType>
{
    private PageType(string value) : base(value)
    {
    }

    public static readonly PageType Item = new("ITEM");

    public static readonly PageType Brandshop = new("BRANDSHOP");

    public TResult Match<TResult>(Func<TResult> onItem, Func<TResult> onBrandshop, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Item => onItem(),
            _ when this == Brandshop => onBrandshop(),
            _ => otherwise(Value)
        };

    public void Match(Action onItem, Action onBrandshop, Action<string> otherwise)
    {
        if (this == Item) onItem();
        else if (this == Brandshop) onBrandshop();
        else otherwise(Value);
    }
}
