using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<Status11>))]
public sealed record Status11 : OpenStringEnum<Status11>
{
    private Status11(string value) : base(value)
    {
    }

    public static readonly Status11 Pending = new("Pending");

    public static readonly Status11 Processing = new("Processing");

    public static readonly Status11 Completed = new("Completed");

    public static readonly Status11 Failed = new("Failed");

    public static readonly Status11 OnHold = new("OnHold");

    public TResult Match<TResult>(Func<TResult> onPending,
        Func<TResult> onProcessing,
        Func<TResult> onCompleted,
        Func<TResult> onFailed,
        Func<TResult> onOnHold,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Pending => onPending(),
            _ when this == Processing => onProcessing(),
            _ when this == Completed => onCompleted(),
            _ when this == Failed => onFailed(),
            _ when this == OnHold => onOnHold(),
            _ => otherwise(Value)
        };

    public void Match(Action onPending,
        Action onProcessing,
        Action onCompleted,
        Action onFailed,
        Action onOnHold,
        Action<string> otherwise)
    {
        if (this == Pending) onPending();
        else if (this == Processing) onProcessing();
        else if (this == Completed) onCompleted();
        else if (this == Failed) onFailed();
        else if (this == OnHold) onOnHold();
        else otherwise(Value);
    }
}
