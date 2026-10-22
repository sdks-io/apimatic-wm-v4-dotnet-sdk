using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetLagTimeError : ApiError
{
    private readonly Optional<V3Lagtime400Error1> _v3Lagtime400Error1Value;

    private readonly Optional<V3Lagtime404Error1> _v3Lagtime404Error1Value;

    private readonly Optional<V3Lagtime500Error1> _v3Lagtime500Error1Value;

    private GetLagTimeError(Optional<V3Lagtime400Error1> v3Lagtime400Error1Value,
        Optional<V3Lagtime404Error1> v3Lagtime404Error1Value,
        Optional<V3Lagtime500Error1> v3Lagtime500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Lagtime400Error1Value = v3Lagtime400Error1Value;
        _v3Lagtime404Error1Value = v3Lagtime404Error1Value;
        _v3Lagtime500Error1Value = v3Lagtime500Error1Value;
    }

    private static GetLagTimeError AsV3Lagtime400Error1(V3Lagtime400Error1 value) =>
        new(Optional<V3Lagtime400Error1>.Some(value), default, default, default);

    private static GetLagTimeError AsV3Lagtime404Error1(V3Lagtime404Error1 value) =>
        new(default, Optional<V3Lagtime404Error1>.Some(value), default, default);

    private static GetLagTimeError AsV3Lagtime500Error1(V3Lagtime500Error1 value) =>
        new(default, default, Optional<V3Lagtime500Error1>.Some(value), default);

    private static GetLagTimeError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3Lagtime400Error1(out V3Lagtime400Error1 value) =>
        _v3Lagtime400Error1Value.TryGetValue(out value);

    public bool TryGetV3Lagtime404Error1(out V3Lagtime404Error1 value) =>
        _v3Lagtime404Error1Value.TryGetValue(out value);

    public bool TryGetV3Lagtime500Error1(out V3Lagtime500Error1 value) =>
        _v3Lagtime500Error1Value.TryGetValue(out value);

    private static Task<GetLagTimeError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3Lagtime400Error1>().As(AsV3Lagtime400Error1),
            404 => response.Json<V3Lagtime404Error1>().As(AsV3Lagtime404Error1),
            500 => response.Json<V3Lagtime500Error1>().As(AsV3Lagtime500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetLagTimeError> Response { get; } = new(Create);
}
