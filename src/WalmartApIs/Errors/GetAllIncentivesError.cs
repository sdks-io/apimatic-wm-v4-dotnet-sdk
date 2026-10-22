using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetAllIncentivesError : ApiError
{
    private readonly Optional<V3PriceIncentives400Error1> _v3PriceIncentives400Error1Value;

    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private GetAllIncentivesError(Optional<V3PriceIncentives400Error1> v3PriceIncentives400Error1Value,
        Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3PriceIncentives400Error1Value = v3PriceIncentives400Error1Value;
        _v3Token400Error1Value = v3Token400Error1Value;
    }

    private static GetAllIncentivesError AsV3PriceIncentives400Error1(V3PriceIncentives400Error1 value) =>
        new(Optional<V3PriceIncentives400Error1>.Some(value), default, default);

    private static GetAllIncentivesError AsV3Token400Error1(V3Token400Error1 value) =>
        new(default, Optional<V3Token400Error1>.Some(value), default);

    private static GetAllIncentivesError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3PriceIncentives400Error1(out V3PriceIncentives400Error1 value) =>
        _v3PriceIncentives400Error1Value.TryGetValue(out value);

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    private static Task<GetAllIncentivesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3PriceIncentives400Error1>().As(AsV3PriceIncentives400Error1),
            403 or 500 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetAllIncentivesError> Response { get; } = new(Create);
}
