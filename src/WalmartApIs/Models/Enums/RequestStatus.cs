using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Status of report request. Possible values are RECEIVED, INPROGRESS, READY, ERROR.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<RequestStatus>))]
public sealed record RequestStatus : OpenStringEnum<RequestStatus>
{
    private RequestStatus(string value) : base(value)
    {
    }

    public static readonly RequestStatus Received = new("RECEIVED");

    public static readonly RequestStatus Inprogress = new("INPROGRESS");

    public static readonly RequestStatus Ready = new("READY");

    public static readonly RequestStatus Error = new("ERROR");

    public TResult Match<TResult>(Func<TResult> onReceived,
        Func<TResult> onInprogress,
        Func<TResult> onReady,
        Func<TResult> onError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Received => onReceived(),
            _ when this == Inprogress => onInprogress(),
            _ when this == Ready => onReady(),
            _ when this == Error => onError(),
            _ => otherwise(Value)
        };

    public void Match(Action onReceived, Action onInprogress, Action onReady, Action onError, Action<string> otherwise)
    {
        if (this == Received) onReceived();
        else if (this == Inprogress) onInprogress();
        else if (this == Ready) onReady();
        else if (this == Error) onError();
        else otherwise(Value);
    }
}
