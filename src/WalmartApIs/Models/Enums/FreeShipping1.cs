using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Indicates if the shipping is free for a recommended item which is a buy box winner.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FreeShipping1>))]
public sealed record FreeShipping1 : OpenStringEnum<FreeShipping1>
{
    private FreeShipping1(string value) : base(value)
    {
    }

    public static readonly FreeShipping1 Yes = new("YES");

    public static readonly FreeShipping1 No = new("NO");

    public TResult Match<TResult>(Func<TResult> onYes, Func<TResult> onNo, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Yes => onYes(),
            _ when this == No => onNo(),
            _ => otherwise(Value)
        };

    public void Match(Action onYes, Action onNo, Action<string> otherwise)
    {
        if (this == Yes) onYes();
        else if (this == No) onNo();
        else otherwise(Value);
    }
}
