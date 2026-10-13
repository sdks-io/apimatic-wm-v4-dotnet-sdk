using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class RegisterClientError : ApiError
{
    private readonly Optional<RegistrationError> _registrationErrorValue;

    private readonly Optional<OAuthError> _oAuthErrorValue;

    private RegisterClientError(Optional<RegistrationError> registrationErrorValue,
        Optional<OAuthError> oAuthErrorValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _registrationErrorValue = registrationErrorValue;
        _oAuthErrorValue = oAuthErrorValue;
    }

    private static RegisterClientError AsRegistrationError(RegistrationError value) =>
        new(Optional<RegistrationError>.Some(value), default, default);

    private static RegisterClientError AsOAuthError(OAuthError value) =>
        new(default, Optional<OAuthError>.Some(value), default);

    private static RegisterClientError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetRegistrationError(out RegistrationError value) => _registrationErrorValue.TryGetValue(out value);

    public bool TryGetOAuthError(out OAuthError value) => _oAuthErrorValue.TryGetValue(out value);

    private static Task<RegisterClientError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 401 => response.Json<RegistrationError>().As(AsRegistrationError),
            429 or 500 => response.Json<OAuthError>().As(AsOAuthError),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<RegisterClientError> Response { get; } = new(Create);
}
