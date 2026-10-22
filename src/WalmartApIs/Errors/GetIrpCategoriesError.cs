using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetIrpCategoriesError : ApiError
{
    private readonly Optional<V3GrowthReviewsAcceleratorCategories400Error1> _v3GrowthReviewsAcceleratorCategories400Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorCategories401Error1> _v3GrowthReviewsAcceleratorCategories401Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorCategories403Error1> _v3GrowthReviewsAcceleratorCategories403Error1Value;

    private readonly Optional<V3InsightsItemsListingQualityItems500Error1> _v3InsightsItemsListingQualityItems500Error1Value;

    private GetIrpCategoriesError(Optional<V3GrowthReviewsAcceleratorCategories400Error1> v3GrowthReviewsAcceleratorCategories400Error1Value,
        Optional<V3GrowthReviewsAcceleratorCategories401Error1> v3GrowthReviewsAcceleratorCategories401Error1Value,
        Optional<V3GrowthReviewsAcceleratorCategories403Error1> v3GrowthReviewsAcceleratorCategories403Error1Value,
        Optional<V3InsightsItemsListingQualityItems500Error1> v3InsightsItemsListingQualityItems500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3GrowthReviewsAcceleratorCategories400Error1Value = v3GrowthReviewsAcceleratorCategories400Error1Value;
        _v3GrowthReviewsAcceleratorCategories401Error1Value = v3GrowthReviewsAcceleratorCategories401Error1Value;
        _v3GrowthReviewsAcceleratorCategories403Error1Value = v3GrowthReviewsAcceleratorCategories403Error1Value;
        _v3InsightsItemsListingQualityItems500Error1Value = v3InsightsItemsListingQualityItems500Error1Value;
    }

    private static GetIrpCategoriesError AsV3GrowthReviewsAcceleratorCategories400Error1(V3GrowthReviewsAcceleratorCategories400Error1 value) =>
        new(Optional<V3GrowthReviewsAcceleratorCategories400Error1>.Some(value), default, default, default, default);

    private static GetIrpCategoriesError AsV3GrowthReviewsAcceleratorCategories401Error1(V3GrowthReviewsAcceleratorCategories401Error1 value) =>
        new(default, Optional<V3GrowthReviewsAcceleratorCategories401Error1>.Some(value), default, default, default);

    private static GetIrpCategoriesError AsV3GrowthReviewsAcceleratorCategories403Error1(V3GrowthReviewsAcceleratorCategories403Error1 value) =>
        new(default, default, Optional<V3GrowthReviewsAcceleratorCategories403Error1>.Some(value), default, default);

    private static GetIrpCategoriesError AsV3InsightsItemsListingQualityItems500Error1(V3InsightsItemsListingQualityItems500Error1 value) =>
        new(default, default, default, Optional<V3InsightsItemsListingQualityItems500Error1>.Some(value), default);

    private static GetIrpCategoriesError AsFallback(RawError value) =>
        new(default, default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3GrowthReviewsAcceleratorCategories400Error1(out V3GrowthReviewsAcceleratorCategories400Error1 value) =>
        _v3GrowthReviewsAcceleratorCategories400Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorCategories401Error1(out V3GrowthReviewsAcceleratorCategories401Error1 value) =>
        _v3GrowthReviewsAcceleratorCategories401Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorCategories403Error1(out V3GrowthReviewsAcceleratorCategories403Error1 value) =>
        _v3GrowthReviewsAcceleratorCategories403Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsListingQualityItems500Error1(out V3InsightsItemsListingQualityItems500Error1 value) =>
        _v3InsightsItemsListingQualityItems500Error1Value.TryGetValue(out value);

    private static Task<GetIrpCategoriesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3GrowthReviewsAcceleratorCategories400Error1>().As(
                AsV3GrowthReviewsAcceleratorCategories400Error1),
            401 => response.Json<V3GrowthReviewsAcceleratorCategories401Error1>().As(
                AsV3GrowthReviewsAcceleratorCategories401Error1),
            403 => response.Json<V3GrowthReviewsAcceleratorCategories403Error1>().As(
                AsV3GrowthReviewsAcceleratorCategories403Error1),
            500 => response.Json<V3InsightsItemsListingQualityItems500Error1>().As(
                AsV3InsightsItemsListingQualityItems500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetIrpCategoriesError> Response { get; } = new(Create);
}
