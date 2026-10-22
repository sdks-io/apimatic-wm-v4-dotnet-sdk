using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetCategoriesListError : ApiError
{
    private readonly Optional<V3InsightsItemsListingQualityCount400Error1> _v3InsightsItemsListingQualityCount400Error1Value;

    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3InsightsItemsListingQualityCount500Error1> _v3InsightsItemsListingQualityCount500Error1Value;

    private GetCategoriesListError(Optional<V3InsightsItemsListingQualityCount400Error1> v3InsightsItemsListingQualityCount400Error1Value,
        Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3InsightsItemsListingQualityCount500Error1> v3InsightsItemsListingQualityCount500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3InsightsItemsListingQualityCount400Error1Value = v3InsightsItemsListingQualityCount400Error1Value;
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3InsightsItemsListingQualityCount500Error1Value = v3InsightsItemsListingQualityCount500Error1Value;
    }

    private static GetCategoriesListError AsV3InsightsItemsListingQualityCount400Error1(V3InsightsItemsListingQualityCount400Error1 value) =>
        new(Optional<V3InsightsItemsListingQualityCount400Error1>.Some(value), default, default, default);

    private static GetCategoriesListError AsV3Token400Error1(V3Token400Error1 value) =>
        new(default, Optional<V3Token400Error1>.Some(value), default, default);

    private static GetCategoriesListError AsV3InsightsItemsListingQualityCount500Error1(V3InsightsItemsListingQualityCount500Error1 value) =>
        new(default, default, Optional<V3InsightsItemsListingQualityCount500Error1>.Some(value), default);

    private static GetCategoriesListError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3InsightsItemsListingQualityCount400Error1(out V3InsightsItemsListingQualityCount400Error1 value) =>
        _v3InsightsItemsListingQualityCount400Error1Value.TryGetValue(out value);

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsListingQualityCount500Error1(out V3InsightsItemsListingQualityCount500Error1 value) =>
        _v3InsightsItemsListingQualityCount500Error1Value.TryGetValue(out value);

    private static Task<GetCategoriesListError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3InsightsItemsListingQualityCount400Error1>().As(
                AsV3InsightsItemsListingQualityCount400Error1),
            401 or 403 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            500 => response.Json<V3InsightsItemsListingQualityCount500Error1>().As(
                AsV3InsightsItemsListingQualityCount500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetCategoriesListError> Response { get; } = new(Create);
}
