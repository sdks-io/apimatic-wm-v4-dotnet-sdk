using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ResponseType1>))]
public sealed record ResponseType1 : OpenStringEnum<ResponseType1>
{
    private ResponseType1(string value) : base(value)
    {
    }

    public static readonly ResponseType1 Code = new("code");

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
