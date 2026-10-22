using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetAssortmentRecommendationTrendsError : ApiError
{
    private readonly Optional<ErrorResponse1> _errorResponse1Value;

    private readonly Optional<V3Token500Error1> _v3Token500Error1Value;

    private GetAssortmentRecommendationTrendsError(Optional<ErrorResponse1> errorResponse1Value,
        Optional<V3Token500Error1> v3Token500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorResponse1Value = errorResponse1Value;
        _v3Token500Error1Value = v3Token500Error1Value;
    }

    private static GetAssortmentRecommendationTrendsError AsErrorResponse1(ErrorResponse1 value) =>
        new(Optional<ErrorResponse1>.Some(value), default, default);

    private static GetAssortmentRecommendationTrendsError AsV3Token500Error1(V3Token500Error1 value) =>
        new(default, Optional<V3Token500Error1>.Some(value), default);

    private static GetAssortmentRecommendationTrendsError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorResponse1(out ErrorResponse1 value) => _errorResponse1Value.TryGetValue(out value);

    public bool TryGetV3Token500Error1(out V3Token500Error1 value) => _v3Token500Error1Value.TryGetValue(out value);

    private static Task<GetAssortmentRecommendationTrendsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<ErrorResponse1>().As(AsErrorResponse1),
            403 => response.Json<V3Token500Error1>().As(AsV3Token500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetAssortmentRecommendationTrendsError> Response { get; } = new(Create);
}
