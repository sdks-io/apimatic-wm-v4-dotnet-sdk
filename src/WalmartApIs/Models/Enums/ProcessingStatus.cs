using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ProcessingStatus>))]
public sealed record ProcessingStatus : OpenStringEnum<ProcessingStatus>
{
    private ProcessingStatus(string value) : base(value)
    {
    }

    public static readonly ProcessingStatus InQueue = new("IN_QUEUE");

    public static readonly ProcessingStatus InProgress = new("IN_PROGRESS");

    public static readonly ProcessingStatus Cancelled = new("CANCELLED");

    public static readonly ProcessingStatus Done = new("DONE");

    public static readonly ProcessingStatus Fatal = new("FATAL");

    public TResult Match<TResult>(Func<TResult> onInQueue,
        Func<TResult> onInProgress,
        Func<TResult> onCancelled,
        Func<TResult> onDone,
        Func<TResult> onFatal,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InQueue => onInQueue(),
            _ when this == InProgress => onInProgress(),
            _ when this == Cancelled => onCancelled(),
            _ when this == Done => onDone(),
            _ when this == Fatal => onFatal(),
            _ => otherwise(Value)
        };

    public void Match(Action onInQueue,
        Action onInProgress,
        Action onCancelled,
        Action onDone,
        Action onFatal,
        Action<string> otherwise)
    {
        if (this == InQueue) onInQueue();
        else if (this == InProgress) onInProgress();
        else if (this == Cancelled) onCancelled();
        else if (this == Done) onDone();
        else if (this == Fatal) onFatal();
        else otherwise(Value);
    }
}
