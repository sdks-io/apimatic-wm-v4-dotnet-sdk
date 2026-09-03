using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class AuthorizeApiError : ApiError
{
    private readonly Optional<AuthorizeError> _authorizeErrorValue;

    private readonly Optional<OAuthError> _oAuthErrorValue;

    private AuthorizeApiError(Optional<AuthorizeError> authorizeErrorValue,
        Optional<OAuthError> oAuthErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _authorizeErrorValue = authorizeErrorValue;
        _oAuthErrorValue = oAuthErrorValue;
    }

    private static AuthorizeApiError AsAuthorizeError(AuthorizeError value) =>
        new(Optional<AuthorizeError>.Some(value), default, default);

    private static AuthorizeApiError AsOAuthError(OAuthError value) =>
        new(default, Optional<OAuthError>.Some(value), default);

    private static AuthorizeApiError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetAuthorizeError(out AuthorizeError value) => _authorizeErrorValue.TryGetValue(out value);

    public bool TryGetOAuthError(out OAuthError value) => _oAuthErrorValue.TryGetValue(out value);

    internal static Task<AuthorizeApiError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 => FromJson<AuthorizeError>(response, ct).As(AsAuthorizeError),
            429 or 500 => FromJson<OAuthError>(response, ct).As(AsOAuthError),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class AuthorizeApiErrorResponse : IErrorResponse<AuthorizeApiError>
{
    public static AuthorizeApiErrorResponse Instance { get; } = new();

    private AuthorizeApiErrorResponse()
    {
    }

    public Task<AuthorizeApiError> Map(HttpResponseMessage response, CancellationToken ct) =>
        AuthorizeApiError.Create(response, ct);
}
