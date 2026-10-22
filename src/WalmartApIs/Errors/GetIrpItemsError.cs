using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetIrpItemsError : ApiError
{
    private readonly Optional<V3GrowthReviewsAcceleratorItems400Error1> _v3GrowthReviewsAcceleratorItems400Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorItems401Error1> _v3GrowthReviewsAcceleratorItems401Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorItems403Error1> _v3GrowthReviewsAcceleratorItems403Error1Value;

    private readonly Optional<V3InsightsItemsListingQualityItems500Error1> _v3InsightsItemsListingQualityItems500Error1Value;

    private GetIrpItemsError(Optional<V3GrowthReviewsAcceleratorItems400Error1> v3GrowthReviewsAcceleratorItems400Error1Value,
        Optional<V3GrowthReviewsAcceleratorItems401Error1> v3GrowthReviewsAcceleratorItems401Error1Value,
        Optional<V3GrowthReviewsAcceleratorItems403Error1> v3GrowthReviewsAcceleratorItems403Error1Value,
        Optional<V3InsightsItemsListingQualityItems500Error1> v3InsightsItemsListingQualityItems500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3GrowthReviewsAcceleratorItems400Error1Value = v3GrowthReviewsAcceleratorItems400Error1Value;
        _v3GrowthReviewsAcceleratorItems401Error1Value = v3GrowthReviewsAcceleratorItems401Error1Value;
        _v3GrowthReviewsAcceleratorItems403Error1Value = v3GrowthReviewsAcceleratorItems403Error1Value;
        _v3InsightsItemsListingQualityItems500Error1Value = v3InsightsItemsListingQualityItems500Error1Value;
    }

    private static GetIrpItemsError AsV3GrowthReviewsAcceleratorItems400Error1(V3GrowthReviewsAcceleratorItems400Error1 value) =>
        new(Optional<V3GrowthReviewsAcceleratorItems400Error1>.Some(value), default, default, default, default);

    private static GetIrpItemsError AsV3GrowthReviewsAcceleratorItems401Error1(V3GrowthReviewsAcceleratorItems401Error1 value) =>
        new(default, Optional<V3GrowthReviewsAcceleratorItems401Error1>.Some(value), default, default, default);

    private static GetIrpItemsError AsV3GrowthReviewsAcceleratorItems403Error1(V3GrowthReviewsAcceleratorItems403Error1 value) =>
        new(default, default, Optional<V3GrowthReviewsAcceleratorItems403Error1>.Some(value), default, default);

    private static GetIrpItemsError AsV3InsightsItemsListingQualityItems500Error1(V3InsightsItemsListingQualityItems500Error1 value) =>
        new(default, default, default, Optional<V3InsightsItemsListingQualityItems500Error1>.Some(value), default);

    private static GetIrpItemsError AsFallback(RawError value) =>
        new(default, default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3GrowthReviewsAcceleratorItems400Error1(out V3GrowthReviewsAcceleratorItems400Error1 value) =>
        _v3GrowthReviewsAcceleratorItems400Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorItems401Error1(out V3GrowthReviewsAcceleratorItems401Error1 value) =>
        _v3GrowthReviewsAcceleratorItems401Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorItems403Error1(out V3GrowthReviewsAcceleratorItems403Error1 value) =>
        _v3GrowthReviewsAcceleratorItems403Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsListingQualityItems500Error1(out V3InsightsItemsListingQualityItems500Error1 value) =>
        _v3InsightsItemsListingQualityItems500Error1Value.TryGetValue(out value);

    private static Task<GetIrpItemsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3GrowthReviewsAcceleratorItems400Error1>().As(
                AsV3GrowthReviewsAcceleratorItems400Error1),
            401 => response.Json<V3GrowthReviewsAcceleratorItems401Error1>().As(
                AsV3GrowthReviewsAcceleratorItems401Error1),
            403 => response.Json<V3GrowthReviewsAcceleratorItems403Error1>().As(
                AsV3GrowthReviewsAcceleratorItems403Error1),
            500 => response.Json<V3InsightsItemsListingQualityItems500Error1>().As(
                AsV3InsightsItemsListingQualityItems500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetIrpItemsError> Response { get; } = new(Create);
}
