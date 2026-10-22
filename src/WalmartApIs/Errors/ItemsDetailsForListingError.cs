using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ItemsDetailsForListingError : ApiError
{
    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3InsightsItemsListingQualityItems500Error1> _v3InsightsItemsListingQualityItems500Error1Value;

    private ItemsDetailsForListingError(Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3InsightsItemsListingQualityItems500Error1> v3InsightsItemsListingQualityItems500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3InsightsItemsListingQualityItems500Error1Value = v3InsightsItemsListingQualityItems500Error1Value;
    }

    private static ItemsDetailsForListingError AsV3Token400Error1(V3Token400Error1 value) =>
        new(Optional<V3Token400Error1>.Some(value), default, default);

    private static ItemsDetailsForListingError AsV3InsightsItemsListingQualityItems500Error1(V3InsightsItemsListingQualityItems500Error1 value) =>
        new(default, Optional<V3InsightsItemsListingQualityItems500Error1>.Some(value), default);

    private static ItemsDetailsForListingError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsListingQualityItems500Error1(out V3InsightsItemsListingQualityItems500Error1 value) =>
        _v3InsightsItemsListingQualityItems500Error1Value.TryGetValue(out value);

    private static Task<ItemsDetailsForListingError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            401 or 403 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            500 => response.Json<V3InsightsItemsListingQualityItems500Error1>().As(
                AsV3InsightsItemsListingQualityItems500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ItemsDetailsForListingError> Response { get; } = new(Create);
}
