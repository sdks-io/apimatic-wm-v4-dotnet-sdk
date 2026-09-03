using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateTokenError : ApiError
{
    private readonly Optional<OAuthError> _oAuthErrorValue;

    private CreateTokenError(Optional<OAuthError> oAuthErrorValue, Optional<RawError> fallback) : base(fallback)
    {
        _oAuthErrorValue = oAuthErrorValue;
    }

    private static CreateTokenError AsOAuthError(OAuthError value) =>
        new(Optional<OAuthError>.Some(value), default);

    private static CreateTokenError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetOAuthError(out OAuthError value) => _oAuthErrorValue.TryGetValue(out value);

    internal static Task<CreateTokenError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 429 or 500 => FromJson<OAuthError>(response, ct).As(AsOAuthError),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateTokenErrorResponse : IErrorResponse<CreateTokenError>
{
    public static CreateTokenErrorResponse Instance { get; } = new();

    private CreateTokenErrorResponse()
    {
    }

    public Task<CreateTokenError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateTokenError.Create(response, ct);
}
