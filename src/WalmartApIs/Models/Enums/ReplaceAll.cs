using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// This is applicable only for promotions
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReplaceAll>))]
public sealed record ReplaceAll : OpenStringEnum<ReplaceAll>
{
    private ReplaceAll(string value) : base(value)
    {
    }

    public static readonly ReplaceAll True = new("true");

    public static readonly ReplaceAll False = new("false");

    public TResult Match<TResult>(Func<TResult> onTrue, Func<TResult> onFalse, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == True => onTrue(),
            _ when this == False => onFalse(),
            _ => otherwise(Value)
        };

    public void Match(Action onTrue, Action onFalse, Action<string> otherwise)
    {
        if (this == True) onTrue();
        else if (this == False) onFalse();
        else otherwise(Value);
    }
}
