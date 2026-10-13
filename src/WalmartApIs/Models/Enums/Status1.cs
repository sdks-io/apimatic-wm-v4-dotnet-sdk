using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status1>))]
public sealed record Status1 : OpenStringEnum<Status1>
{
    private Status1(string value) : base(value)
    {
    }

    public static readonly Status1 Accepted = new("ACCEPTED");

    public static readonly Status1 Invalid = new("INVALID");

    public TResult Match<TResult>(Func<TResult> onAccepted, Func<TResult> onInvalid, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Accepted => onAccepted(),
            _ when this == Invalid => onInvalid(),
            _ => otherwise(Value)
        };

    public void Match(Action onAccepted, Action onInvalid, Action<string> otherwise)
    {
        if (this == Accepted) onAccepted();
        else if (this == Invalid) onInvalid();
        else otherwise(Value);
    }
}
