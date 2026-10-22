using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// This is applicable only for promotions
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ComparisonPriceType>))]
public sealed record ComparisonPriceType : OpenStringEnum<ComparisonPriceType>
{
    private ComparisonPriceType(string value) : base(value)
    {
    }

    public static readonly ComparisonPriceType Base = new("BASE");

    public TResult Match<TResult>(Func<TResult> onBase, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Base => onBase(),
            _ => otherwise(Value)
        };

    public void Match(Action onBase, Action<string> otherwise)
    {
        if (this == Base) onBase();
        else otherwise(Value);
    }
}
