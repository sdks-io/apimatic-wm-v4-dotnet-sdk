using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Can be one of the following: RECEIVED, INPROGRESS, PROCESSED, or ERROR
/// </summary>
[JsonConverter(typeof(StringEnumConverter<FeedStatus>))]
public sealed record FeedStatus : OpenStringEnum<FeedStatus>
{
    private FeedStatus(string value) : base(value)
    {
    }

    public static readonly FeedStatus Received = new("RECEIVED");

    public static readonly FeedStatus Inprogress = new("INPROGRESS");

    public static readonly FeedStatus Processed = new("PROCESSED");

    public static readonly FeedStatus Error = new("ERROR");

    public TResult Match<TResult>(Func<TResult> onReceived,
        Func<TResult> onInprogress,
        Func<TResult> onProcessed,
        Func<TResult> onError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Received => onReceived(),
            _ when this == Inprogress => onInprogress(),
            _ when this == Processed => onProcessed(),
            _ when this == Error => onError(),
            _ => otherwise(Value)
        };

    public void Match(Action onReceived,
        Action onInprogress,
        Action onProcessed,
        Action onError,
        Action<string> otherwise)
    {
        if (this == Received) onReceived();
        else if (this == Inprogress) onInprogress();
        else if (this == Processed) onProcessed();
        else if (this == Error) onError();
        else otherwise(Value);
    }
}
