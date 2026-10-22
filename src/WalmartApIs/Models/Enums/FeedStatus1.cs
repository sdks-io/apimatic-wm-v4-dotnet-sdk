using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FeedStatus1>))]
public sealed record FeedStatus1 : OpenStringEnum<FeedStatus1>
{
    private FeedStatus1(string value) : base(value)
    {
    }

    public static readonly FeedStatus1 Received = new("RECEIVED");

    public static readonly FeedStatus1 Inprogress = new("INPROGRESS");

    public static readonly FeedStatus1 Processed = new("PROCESSED");

    public static readonly FeedStatus1 Error = new("ERROR");

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
