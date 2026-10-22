using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateSeoRecommendationsError : ApiError
{
    private readonly Optional<V3SeoRecommendationUpdateItems400Error1> _v3SeoRecommendationUpdateItems400Error1Value;

    private readonly Optional<V3SeoRecommendationUpdateItems404Error1> _v3SeoRecommendationUpdateItems404Error1Value;

    private readonly Optional<V3SeoRecommendationUpdateItems500Error1> _v3SeoRecommendationUpdateItems500Error1Value;

    private UpdateSeoRecommendationsError(Optional<V3SeoRecommendationUpdateItems400Error1> v3SeoRecommendationUpdateItems400Error1Value,
        Optional<V3SeoRecommendationUpdateItems404Error1> v3SeoRecommendationUpdateItems404Error1Value,
        Optional<V3SeoRecommendationUpdateItems500Error1> v3SeoRecommendationUpdateItems500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3SeoRecommendationUpdateItems400Error1Value = v3SeoRecommendationUpdateItems400Error1Value;
        _v3SeoRecommendationUpdateItems404Error1Value = v3SeoRecommendationUpdateItems404Error1Value;
        _v3SeoRecommendationUpdateItems500Error1Value = v3SeoRecommendationUpdateItems500Error1Value;
    }

    private static UpdateSeoRecommendationsError AsV3SeoRecommendationUpdateItems400Error1(V3SeoRecommendationUpdateItems400Error1 value) =>
        new(Optional<V3SeoRecommendationUpdateItems400Error1>.Some(value), default, default, default);

    private static UpdateSeoRecommendationsError AsV3SeoRecommendationUpdateItems404Error1(V3SeoRecommendationUpdateItems404Error1 value) =>
        new(default, Optional<V3SeoRecommendationUpdateItems404Error1>.Some(value), default, default);

    private static UpdateSeoRecommendationsError AsV3SeoRecommendationUpdateItems500Error1(V3SeoRecommendationUpdateItems500Error1 value) =>
        new(default, default, Optional<V3SeoRecommendationUpdateItems500Error1>.Some(value), default);

    private static UpdateSeoRecommendationsError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3SeoRecommendationUpdateItems400Error1(out V3SeoRecommendationUpdateItems400Error1 value) =>
        _v3SeoRecommendationUpdateItems400Error1Value.TryGetValue(out value);

    public bool TryGetV3SeoRecommendationUpdateItems404Error1(out V3SeoRecommendationUpdateItems404Error1 value) =>
        _v3SeoRecommendationUpdateItems404Error1Value.TryGetValue(out value);

    public bool TryGetV3SeoRecommendationUpdateItems500Error1(out V3SeoRecommendationUpdateItems500Error1 value) =>
        _v3SeoRecommendationUpdateItems500Error1Value.TryGetValue(out value);

    private static Task<UpdateSeoRecommendationsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3SeoRecommendationUpdateItems400Error1>().As(
                AsV3SeoRecommendationUpdateItems400Error1),
            404 => response.Json<V3SeoRecommendationUpdateItems404Error1>().As(
                AsV3SeoRecommendationUpdateItems404Error1),
            500 => response.Json<V3SeoRecommendationUpdateItems500Error1>().As(
                AsV3SeoRecommendationUpdateItems500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<UpdateSeoRecommendationsError> Response { get; } = new(Create);
}
