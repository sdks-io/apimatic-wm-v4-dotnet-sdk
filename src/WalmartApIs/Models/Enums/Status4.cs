using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Outcome of the fee estimate.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Status4>))]
public sealed record Status4 : OpenStringEnum<Status4>
{
    private Status4(string value) : base(value)
    {
    }

    public static readonly Status4 Success = new("Success");

    public static readonly Status4 ClientError = new("ClientError");

    public static readonly Status4 ServiceError = new("ServiceError");

    public TResult Match<TResult>(Func<TResult> onSuccess,
        Func<TResult> onClientError,
        Func<TResult> onServiceError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Success => onSuccess(),
            _ when this == ClientError => onClientError(),
            _ when this == ServiceError => onServiceError(),
            _ => otherwise(Value)
        };

    public void Match(Action onSuccess, Action onClientError, Action onServiceError, Action<string> otherwise)
    {
        if (this == Success) onSuccess();
        else if (this == ClientError) onClientError();
        else if (this == ServiceError) onServiceError();
        else otherwise(Value);
    }
}
