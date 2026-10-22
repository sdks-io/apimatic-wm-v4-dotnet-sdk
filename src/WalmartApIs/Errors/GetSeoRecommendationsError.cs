using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetSeoRecommendationsError : ApiError
{
    private readonly Optional<V3SeoRecommendationGetItems400Error1> _v3SeoRecommendationGetItems400Error1Value;

    private readonly Optional<V3SeoRecommendationGetItems500Error1> _v3SeoRecommendationGetItems500Error1Value;

    private GetSeoRecommendationsError(Optional<V3SeoRecommendationGetItems400Error1> v3SeoRecommendationGetItems400Error1Value,
        Optional<V3SeoRecommendationGetItems500Error1> v3SeoRecommendationGetItems500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3SeoRecommendationGetItems400Error1Value = v3SeoRecommendationGetItems400Error1Value;
        _v3SeoRecommendationGetItems500Error1Value = v3SeoRecommendationGetItems500Error1Value;
    }

    private static GetSeoRecommendationsError AsV3SeoRecommendationGetItems400Error1(V3SeoRecommendationGetItems400Error1 value) =>
        new(Optional<V3SeoRecommendationGetItems400Error1>.Some(value), default, default);

    private static GetSeoRecommendationsError AsV3SeoRecommendationGetItems500Error1(V3SeoRecommendationGetItems500Error1 value) =>
        new(default, Optional<V3SeoRecommendationGetItems500Error1>.Some(value), default);

    private static GetSeoRecommendationsError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3SeoRecommendationGetItems400Error1(out V3SeoRecommendationGetItems400Error1 value) =>
        _v3SeoRecommendationGetItems400Error1Value.TryGetValue(out value);

    public bool TryGetV3SeoRecommendationGetItems500Error1(out V3SeoRecommendationGetItems500Error1 value) =>
        _v3SeoRecommendationGetItems500Error1Value.TryGetValue(out value);

    private static Task<GetSeoRecommendationsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3SeoRecommendationGetItems400Error1>().As(AsV3SeoRecommendationGetItems400Error1),
            500 => response.Json<V3SeoRecommendationGetItems500Error1>().As(AsV3SeoRecommendationGetItems500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetSeoRecommendationsError> Response { get; } = new(Create);
}
