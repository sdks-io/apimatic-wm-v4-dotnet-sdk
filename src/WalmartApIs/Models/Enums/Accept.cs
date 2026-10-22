using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Accept>))]
public sealed record Accept : OpenStringEnum<Accept>
{
    private Accept(string value) : base(value)
    {
    }

    public static readonly Accept ApplicationJson = new("application/json");

    public TResult Match<TResult>(Func<TResult> onApplicationJson, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ApplicationJson => onApplicationJson(),
            _ => otherwise(Value)
        };

    public void Match(Action onApplicationJson, Action<string> otherwise)
    {
        if (this == ApplicationJson) onApplicationJson();
        else otherwise(Value);
    }
}
