using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetReturnsError : ApiError
{
    private readonly Optional<ErrorResponse3> _errorResponse3Value;

    private readonly Optional<Unauthorized1> _unauthorized1Value;

    private readonly Optional<Forbidden1> _forbidden1Value;

    private readonly Optional<TooManyRequests1> _tooManyRequests1Value;

    private readonly Optional<ErrorResponses> _errorResponsesValue;

    private GetReturnsError(Optional<ErrorResponse3> errorResponse3Value,
        Optional<Unauthorized1> unauthorized1Value,
        Optional<Forbidden1> forbidden1Value,
        Optional<TooManyRequests1> tooManyRequests1Value,
        Optional<ErrorResponses> errorResponsesValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorResponse3Value = errorResponse3Value;
        _unauthorized1Value = unauthorized1Value;
        _forbidden1Value = forbidden1Value;
        _tooManyRequests1Value = tooManyRequests1Value;
        _errorResponsesValue = errorResponsesValue;
    }

    private static GetReturnsError AsErrorResponse3(ErrorResponse3 value) =>
        new(Optional<ErrorResponse3>.Some(value), default, default, default, default, default);

    private static GetReturnsError AsUnauthorized1(Unauthorized1 value) =>
        new(default, Optional<Unauthorized1>.Some(value), default, default, default, default);

    private static GetReturnsError AsForbidden1(Forbidden1 value) =>
        new(default, default, Optional<Forbidden1>.Some(value), default, default, default);

    private static GetReturnsError AsTooManyRequests1(TooManyRequests1 value) =>
        new(default, default, default, Optional<TooManyRequests1>.Some(value), default, default);

    private static GetReturnsError AsErrorResponses(ErrorResponses value) =>
        new(default, default, default, default, Optional<ErrorResponses>.Some(value), default);

    private static GetReturnsError AsFallback(RawError value) =>
        new(default, default, default, default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorResponse3(out ErrorResponse3 value) => _errorResponse3Value.TryGetValue(out value);

    public bool TryGetUnauthorized1(out Unauthorized1 value) => _unauthorized1Value.TryGetValue(out value);

    public bool TryGetForbidden1(out Forbidden1 value) => _forbidden1Value.TryGetValue(out value);

    public bool TryGetTooManyRequests1(out TooManyRequests1 value) => _tooManyRequests1Value.TryGetValue(out value);

    public bool TryGetErrorResponses(out ErrorResponses value) => _errorResponsesValue.TryGetValue(out value);

    private static Task<GetReturnsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<ErrorResponse3>().As(AsErrorResponse3),
            401 => response.Json<Unauthorized1>().As(AsUnauthorized1),
            403 => response.Json<Forbidden1>().As(AsForbidden1),
            429 => response.Json<TooManyRequests1>().As(AsTooManyRequests1),
            500 => response.Json<ErrorResponses>().As(AsErrorResponses),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetReturnsError> Response { get; } = new(Create);
}
