using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class TokenApiError : ApiError
{
    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3Token401Error1> _v3Token401Error1Value;

    private readonly Optional<V3Token500Error1> _v3Token500Error1Value;

    private TokenApiError(Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3Token401Error1> v3Token401Error1Value,
        Optional<V3Token500Error1> v3Token500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3Token401Error1Value = v3Token401Error1Value;
        _v3Token500Error1Value = v3Token500Error1Value;
    }

    private static TokenApiError AsV3Token400Error1(V3Token400Error1 value) =>
        new(Optional<V3Token400Error1>.Some(value), default, default, default);

    private static TokenApiError AsV3Token401Error1(V3Token401Error1 value) =>
        new(default, Optional<V3Token401Error1>.Some(value), default, default);

    private static TokenApiError AsV3Token500Error1(V3Token500Error1 value) =>
        new(default, default, Optional<V3Token500Error1>.Some(value), default);

    private static TokenApiError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3Token401Error1(out V3Token401Error1 value) => _v3Token401Error1Value.TryGetValue(out value);

    public bool TryGetV3Token500Error1(out V3Token500Error1 value) => _v3Token500Error1Value.TryGetValue(out value);

    private static Task<TokenApiError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            401 => response.Json<V3Token401Error1>().As(AsV3Token401Error1),
            500 => response.Json<V3Token500Error1>().As(AsV3Token500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<TokenApiError> Response { get; } = new(Create);
}
