using System.Net.Http;
using System.Threading;
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

    public bool TryGetRegistrationError(out RegistrationError value) =>
        _registrationErrorValue.TryGetValue(out value);

    public bool TryGetOAuthError(out OAuthError value) => _oAuthErrorValue.TryGetValue(out value);

    internal static Task<RegisterClientError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 => FromJson<RegistrationError>(response, ct).As(AsRegistrationError),
            429 or 500 => FromJson<OAuthError>(response, ct).As(AsOAuthError),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class RegisterClientErrorResponse : IErrorResponse<RegisterClientError>
{
    public static RegisterClientErrorResponse Instance { get; } = new();

    private RegisterClientErrorResponse()
    {
    }

    public Task<RegisterClientError> Map(HttpResponseMessage response, CancellationToken ct) =>
        RegisterClientError.Create(response, ct);
}
