using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<RequestStatus4>))]
public sealed record RequestStatus4 : OpenStringEnum<RequestStatus4>
{
    private RequestStatus4(string value) : base(value)
    {
    }

    public static readonly RequestStatus4 Received = new("RECEIVED");

    public static readonly RequestStatus4 Inprogress = new("INPROGRESS");

    public static readonly RequestStatus4 Ready = new("READY");

    public static readonly RequestStatus4 Error = new("ERROR");

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
