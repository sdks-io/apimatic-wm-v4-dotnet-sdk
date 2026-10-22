using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type |
/// | --- | ----------- | ------- |
/// | ENROLL | To enroll items into the program | string |
/// | DISENROLL | To opt out items from the program | string |
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status1>))]
public sealed record Status1 : OpenStringEnum<Status1>
{
    private Status1(string value) : base(value)
    {
    }

    public static readonly Status1 Enroll = new("ENROLL");

    public static readonly Status1 Disenroll = new("DISENROLL");

    public TResult Match<TResult>(Func<TResult> onEnroll, Func<TResult> onDisenroll, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Enroll => onEnroll(),
            _ when this == Disenroll => onDisenroll(),
            _ => otherwise(Value)
        };

    public void Match(Action onEnroll, Action onDisenroll, Action<string> otherwise)
    {
        if (this == Enroll) onEnroll();
        else if (this == Disenroll) onDisenroll();
        else otherwise(Value);
    }
}
