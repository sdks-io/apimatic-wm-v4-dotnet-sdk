using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// The type of filter to apply.
/// <para>
/// &lt;strong style="color: green;"&gt;Market availability: Global&lt;/strong&gt;
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RowFilterType>))]
public sealed record RowFilterType : OpenStringEnum<RowFilterType>
{
    private RowFilterType(string value) : base(value)
    {
    }

    public static readonly RowFilterType RangeFilter = new("rangeFilter");

    public static readonly RowFilterType EnumFilter = new("enumFilter");

    public static readonly RowFilterType MultiValueFilter = new("multiValueFilter");

    public TResult Match<TResult>(Func<TResult> onRangeFilter,
        Func<TResult> onEnumFilter,
        Func<TResult> onMultiValueFilter,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == RangeFilter => onRangeFilter(),
            _ when this == EnumFilter => onEnumFilter(),
            _ when this == MultiValueFilter => onMultiValueFilter(),
            _ => otherwise(Value)
        };

    public void Match(Action onRangeFilter, Action onEnumFilter, Action onMultiValueFilter, Action<string> otherwise)
    {
        if (this == RangeFilter) onRangeFilter();
        else if (this == EnumFilter) onEnumFilter();
        else if (this == MultiValueFilter) onMultiValueFilter();
        else otherwise(Value);
    }
}
