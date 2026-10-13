using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status3>))]
public sealed record Status3 : OpenStringEnum<Status3>
{
    private Status3(string value) : base(value)
    {
    }

    public static readonly Status3 Resolved = new("Resolved");

    public static readonly Status3 Closed = new("Closed");

    public TResult Match<TResult>(Func<TResult> onResolved, Func<TResult> onClosed, Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Resolved => onResolved(),
            _ when this == Closed => onClosed(),
            _ => otherwise(Value)
        };

    public void Match(Action onResolved, Action onClosed, Action<string> otherwise)
    {
        if (this == Resolved) onResolved();
        else if (this == Closed) onClosed();
        else otherwise(Value);
    }
}
