using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<GatewayErrorCategory>))]
public sealed record GatewayErrorCategory : OpenStringEnum<GatewayErrorCategory>
{
    private GatewayErrorCategory(string value) : base(value)
    {
    }

    public static readonly GatewayErrorCategory InternalDataError = new("INTERNAL_DATA_ERROR");

    public static readonly GatewayErrorCategory ExternalDataError = new("EXTERNAL_DATA_ERROR");

    public static readonly GatewayErrorCategory SystemError = new("SYSTEM_ERROR");

    public TResult Match<TResult>(Func<TResult> onInternalDataError,
        Func<TResult> onExternalDataError,
        Func<TResult> onSystemError,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InternalDataError => onInternalDataError(),
            _ when this == ExternalDataError => onExternalDataError(),
            _ when this == SystemError => onSystemError(),
            _ => otherwise(Value)
        };

    public void Match(Action onInternalDataError,
        Action onExternalDataError,
        Action onSystemError,
        Action<string> otherwise)
    {
        if (this == InternalDataError) onInternalDataError();
        else if (this == ExternalDataError) onExternalDataError();
        else if (this == SystemError) onSystemError();
        else otherwise(Value);
    }
}
