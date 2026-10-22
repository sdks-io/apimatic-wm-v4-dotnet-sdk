using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<WmGlobalVersion>))]
public sealed record WmGlobalVersion : OpenStringEnum<WmGlobalVersion>
{
    private WmGlobalVersion(string value) : base(value)
    {
    }

    /// <summary>
    /// API version 3.1.
    /// </summary>
    public static readonly WmGlobalVersion _31 = new("3.1");

    public TResult Match<TResult>(Func<TResult> on_31, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == _31 => on_31(),
            _ => otherwise(Value)
        };

    public void Match(Action on_31, Action<string> otherwise)
    {
        if (this == _31) on_31();
        else otherwise(Value);
    }
}
