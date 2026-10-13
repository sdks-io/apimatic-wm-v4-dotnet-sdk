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

    private static CreateTokenError AsOAuthError(OAuthError value) => new(Optional<OAuthError>.Some(value), default);

    private static CreateTokenError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetOAuthError(out OAuthError value) => _oAuthErrorValue.TryGetValue(out value);

    private static Task<CreateTokenError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 401 or 429 or 500 => response.Json<OAuthError>().As(AsOAuthError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateTokenError> Response { get; } = new(Create);
}
