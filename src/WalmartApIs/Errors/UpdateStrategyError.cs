using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateStrategyError : ApiError
{
    private readonly Optional<V3RepricerStrategy400Error1> _v3RepricerStrategy400Error1Value;

    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private UpdateStrategyError(Optional<V3RepricerStrategy400Error1> v3RepricerStrategy400Error1Value,
        Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3RepricerStrategy400Error1Value = v3RepricerStrategy400Error1Value;
        _v3Token400Error1Value = v3Token400Error1Value;
    }

    private static UpdateStrategyError AsV3RepricerStrategy400Error1(V3RepricerStrategy400Error1 value) =>
        new(Optional<V3RepricerStrategy400Error1>.Some(value), default, default);

    private static UpdateStrategyError AsV3Token400Error1(V3Token400Error1 value) =>
        new(default, Optional<V3Token400Error1>.Some(value), default);

    private static UpdateStrategyError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3RepricerStrategy400Error1(out V3RepricerStrategy400Error1 value) =>
        _v3RepricerStrategy400Error1Value.TryGetValue(out value);

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    private static Task<UpdateStrategyError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3RepricerStrategy400Error1>().As(AsV3RepricerStrategy400Error1),
            403 or 500 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateStrategyError> Response { get; } = new(Create);
}
