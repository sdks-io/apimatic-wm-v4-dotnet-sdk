using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ResponseType>))]
public sealed record ResponseType : OpenStringEnum<ResponseType>
{
    private ResponseType(string value) : base(value)
    {
    }

    public static readonly ResponseType Code = new("code");

    public TResult Match<TResult>(Func<TResult> onCode, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Code => onCode(),
            _ => otherwise(Value)
        };

    public void Match(Action onCode, Action<string> otherwise)
    {
        if (this == Code) onCode();
        else otherwise(Value);
    }
}
