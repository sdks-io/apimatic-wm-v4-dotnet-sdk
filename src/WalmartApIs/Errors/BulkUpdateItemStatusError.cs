using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class BulkUpdateItemStatusError : ApiError
{
    private readonly Optional<V3GrowthReviewsAcceleratorItemsStatus400Error1> _v3GrowthReviewsAcceleratorItemsStatus400Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorItemsStatus401Error1> _v3GrowthReviewsAcceleratorItemsStatus401Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorItemsStatus403Error1> _v3GrowthReviewsAcceleratorItemsStatus403Error1Value;

    private readonly Optional<V3GrowthReviewsAcceleratorItemsStatus500Error1> _v3GrowthReviewsAcceleratorItemsStatus500Error1Value;

    private BulkUpdateItemStatusError(Optional<V3GrowthReviewsAcceleratorItemsStatus400Error1> v3GrowthReviewsAcceleratorItemsStatus400Error1Value,
        Optional<V3GrowthReviewsAcceleratorItemsStatus401Error1> v3GrowthReviewsAcceleratorItemsStatus401Error1Value,
        Optional<V3GrowthReviewsAcceleratorItemsStatus403Error1> v3GrowthReviewsAcceleratorItemsStatus403Error1Value,
        Optional<V3GrowthReviewsAcceleratorItemsStatus500Error1> v3GrowthReviewsAcceleratorItemsStatus500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3GrowthReviewsAcceleratorItemsStatus400Error1Value = v3GrowthReviewsAcceleratorItemsStatus400Error1Value;
        _v3GrowthReviewsAcceleratorItemsStatus401Error1Value = v3GrowthReviewsAcceleratorItemsStatus401Error1Value;
        _v3GrowthReviewsAcceleratorItemsStatus403Error1Value = v3GrowthReviewsAcceleratorItemsStatus403Error1Value;
        _v3GrowthReviewsAcceleratorItemsStatus500Error1Value = v3GrowthReviewsAcceleratorItemsStatus500Error1Value;
    }

    private static BulkUpdateItemStatusError AsV3GrowthReviewsAcceleratorItemsStatus400Error1(V3GrowthReviewsAcceleratorItemsStatus400Error1 value) =>
        new(Optional<V3GrowthReviewsAcceleratorItemsStatus400Error1>.Some(value), default, default, default, default);

    private static BulkUpdateItemStatusError AsV3GrowthReviewsAcceleratorItemsStatus401Error1(V3GrowthReviewsAcceleratorItemsStatus401Error1 value) =>
        new(default, Optional<V3GrowthReviewsAcceleratorItemsStatus401Error1>.Some(value), default, default, default);

    private static BulkUpdateItemStatusError AsV3GrowthReviewsAcceleratorItemsStatus403Error1(V3GrowthReviewsAcceleratorItemsStatus403Error1 value) =>
        new(default, default, Optional<V3GrowthReviewsAcceleratorItemsStatus403Error1>.Some(value), default, default);

    private static BulkUpdateItemStatusError AsV3GrowthReviewsAcceleratorItemsStatus500Error1(V3GrowthReviewsAcceleratorItemsStatus500Error1 value) =>
        new(default, default, default, Optional<V3GrowthReviewsAcceleratorItemsStatus500Error1>.Some(value), default);

    private static BulkUpdateItemStatusError AsFallback(RawError value) =>
        new(default, default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3GrowthReviewsAcceleratorItemsStatus400Error1(out V3GrowthReviewsAcceleratorItemsStatus400Error1 value) =>
        _v3GrowthReviewsAcceleratorItemsStatus400Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorItemsStatus401Error1(out V3GrowthReviewsAcceleratorItemsStatus401Error1 value) =>
        _v3GrowthReviewsAcceleratorItemsStatus401Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorItemsStatus403Error1(out V3GrowthReviewsAcceleratorItemsStatus403Error1 value) =>
        _v3GrowthReviewsAcceleratorItemsStatus403Error1Value.TryGetValue(out value);

    public bool TryGetV3GrowthReviewsAcceleratorItemsStatus500Error1(out V3GrowthReviewsAcceleratorItemsStatus500Error1 value) =>
        _v3GrowthReviewsAcceleratorItemsStatus500Error1Value.TryGetValue(out value);

    private static Task<BulkUpdateItemStatusError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3GrowthReviewsAcceleratorItemsStatus400Error1>().As(
                AsV3GrowthReviewsAcceleratorItemsStatus400Error1),
            401 => response.Json<V3GrowthReviewsAcceleratorItemsStatus401Error1>().As(
                AsV3GrowthReviewsAcceleratorItemsStatus401Error1),
            403 => response.Json<V3GrowthReviewsAcceleratorItemsStatus403Error1>().As(
                AsV3GrowthReviewsAcceleratorItemsStatus403Error1),
            500 => response.Json<V3GrowthReviewsAcceleratorItemsStatus500Error1>().As(
                AsV3GrowthReviewsAcceleratorItemsStatus500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<BulkUpdateItemStatusError> Response { get; } = new(Create);
}
