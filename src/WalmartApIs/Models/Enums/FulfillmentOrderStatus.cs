using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<FulfillmentOrderStatus>))]
public sealed record FulfillmentOrderStatus : OpenStringEnum<FulfillmentOrderStatus>
{
    private FulfillmentOrderStatus(string value) : base(value)
    {
    }

    public static readonly FulfillmentOrderStatus Received = new("RECEIVED");

    public static readonly FulfillmentOrderStatus Invalid = new("INVALID");

    public static readonly FulfillmentOrderStatus Planning = new("PLANNING");

    public static readonly FulfillmentOrderStatus Processing = new("PROCESSING");

    public static readonly FulfillmentOrderStatus Cancelled = new("CANCELLED");

    public static readonly FulfillmentOrderStatus Complete = new("COMPLETE");

    public static readonly FulfillmentOrderStatus CompletePartialled = new("COMPLETE_PARTIALLED");

    public static readonly FulfillmentOrderStatus Unfulfillable = new("UNFULFILLABLE");

    public TResult Match<TResult>(Func<TResult> onReceived,
        Func<TResult> onInvalid,
        Func<TResult> onPlanning,
        Func<TResult> onProcessing,
        Func<TResult> onCancelled,
        Func<TResult> onComplete,
        Func<TResult> onCompletePartialled,
        Func<TResult> onUnfulfillable,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Received => onReceived(),
            _ when this == Invalid => onInvalid(),
            _ when this == Planning => onPlanning(),
            _ when this == Processing => onProcessing(),
            _ when this == Cancelled => onCancelled(),
            _ when this == Complete => onComplete(),
            _ when this == CompletePartialled => onCompletePartialled(),
            _ when this == Unfulfillable => onUnfulfillable(),
            _ => otherwise(Value)
        };

    public void Match(Action onReceived,
        Action onInvalid,
        Action onPlanning,
        Action onProcessing,
        Action onCancelled,
        Action onComplete,
        Action onCompletePartialled,
        Action onUnfulfillable,
        Action<string> otherwise)
    {
        if (this == Received) onReceived();
        else if (this == Invalid) onInvalid();
        else if (this == Planning) onPlanning();
        else if (this == Processing) onProcessing();
        else if (this == Cancelled) onCancelled();
        else if (this == Complete) onComplete();
        else if (this == CompletePartialled) onCompletePartialled();
        else if (this == Unfulfillable) onUnfulfillable();
        else otherwise(Value);
    }
}
