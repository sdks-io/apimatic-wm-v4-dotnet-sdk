using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Machine-readable error code.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Error>))]
public sealed record Error : OpenStringEnum<Error>
{
    private Error(string value) : base(value)
    {
    }

    public static readonly Error InvalidRequest = new("invalid_request");

    public static readonly Error InvalidClient = new("invalid_client");

    public static readonly Error InvalidGrant = new("invalid_grant");

    public static readonly Error UnauthorizedClient = new("unauthorized_client");

    public static readonly Error UnsupportedGrantType = new("unsupported_grant_type");

    public static readonly Error InvalidScope = new("invalid_scope");

    public TResult Match<TResult>(Func<TResult> onInvalidRequest,
        Func<TResult> onInvalidClient,
        Func<TResult> onInvalidGrant,
        Func<TResult> onUnauthorizedClient,
        Func<TResult> onUnsupportedGrantType,
        Func<TResult> onInvalidScope,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InvalidRequest => onInvalidRequest(),
            _ when this == InvalidClient => onInvalidClient(),
            _ when this == InvalidGrant => onInvalidGrant(),
            _ when this == UnauthorizedClient => onUnauthorizedClient(),
            _ when this == UnsupportedGrantType => onUnsupportedGrantType(),
            _ when this == InvalidScope => onInvalidScope(),
            _ => otherwise(Value)
        };

    public void Match(Action onInvalidRequest,
        Action onInvalidClient,
        Action onInvalidGrant,
        Action onUnauthorizedClient,
        Action onUnsupportedGrantType,
        Action onInvalidScope,
        Action<string> otherwise)
    {
        if (this == InvalidRequest) onInvalidRequest();
        else if (this == InvalidClient) onInvalidClient();
        else if (this == InvalidGrant) onInvalidGrant();
        else if (this == UnauthorizedClient) onUnauthorizedClient();
        else if (this == UnsupportedGrantType) onUnsupportedGrantType();
        else if (this == InvalidScope) onInvalidScope();
        else otherwise(Value);
    }
}
