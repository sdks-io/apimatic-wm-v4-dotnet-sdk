using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status2>))]
public sealed record Status2 : OpenStringEnum<Status2>
{
    private Status2(string value) : base(value)
    {
    }

    public static readonly Status2 Open = new("Open");

    public static readonly Status2 Closed = new("Closed");

    public static readonly Status2 Transferred = new("Transferred");

    public TResult Match<TResult>(Func<TResult> onOpen,
        Func<TResult> onClosed,
        Func<TResult> onTransferred,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Open => onOpen(),
            _ when this == Closed => onClosed(),
            _ when this == Transferred => onTransferred(),
            _ => otherwise(Value)
        };

    public void Match(Action onOpen, Action onClosed, Action onTransferred, Action<string> otherwise)
    {
        if (this == Open) onOpen();
        else if (this == Closed) onClosed();
        else if (this == Transferred) onTransferred();
        else otherwise(Value);
    }
}
