using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Machine-readable error code.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Error1>))]
public sealed record Error1 : OpenStringEnum<Error1>
{
    private Error1(string value) : base(value)
    {
    }

    public static readonly Error1 InvalidRequest = new("invalid_request");

    public static readonly Error1 UnauthorizedClient = new("unauthorized_client");

    public static readonly Error1 AccessDenied = new("access_denied");

    public static readonly Error1 UnsupportedResponseType = new("unsupported_response_type");

    public static readonly Error1 InvalidScope = new("invalid_scope");

    public static readonly Error1 ServerError = new("server_error");

    public static readonly Error1 TemporarilyUnavailable = new("temporarily_unavailable");

    public TResult Match<TResult>(Func<TResult> onInvalidRequest,
        Func<TResult> onUnauthorizedClient,
        Func<TResult> onAccessDenied,
        Func<TResult> onUnsupportedResponseType,
        Func<TResult> onInvalidScope,
        Func<TResult> onServerError,
        Func<TResult> onTemporarilyUnavailable,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == InvalidRequest => onInvalidRequest(),
            _ when this == UnauthorizedClient => onUnauthorizedClient(),
            _ when this == AccessDenied => onAccessDenied(),
            _ when this == UnsupportedResponseType => onUnsupportedResponseType(),
            _ when this == InvalidScope => onInvalidScope(),
            _ when this == ServerError => onServerError(),
            _ when this == TemporarilyUnavailable => onTemporarilyUnavailable(),
            _ => otherwise(Value)
        };

    public void Match(Action onInvalidRequest,
        Action onUnauthorizedClient,
        Action onAccessDenied,
        Action onUnsupportedResponseType,
        Action onInvalidScope,
        Action onServerError,
        Action onTemporarilyUnavailable,
        Action<string> otherwise)
    {
        if (this == InvalidRequest) onInvalidRequest();
        else if (this == UnauthorizedClient) onUnauthorizedClient();
        else if (this == AccessDenied) onAccessDenied();
        else if (this == UnsupportedResponseType) onUnsupportedResponseType();
        else if (this == InvalidScope) onInvalidScope();
        else if (this == ServerError) onServerError();
        else if (this == TemporarilyUnavailable) onTemporarilyUnavailable();
        else otherwise(Value);
    }
}
