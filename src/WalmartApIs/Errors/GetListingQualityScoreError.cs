using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetListingQualityScoreError : ApiError
{
    private readonly Optional<V3InsightsItemsListingQualityScore400Error1> _v3InsightsItemsListingQualityScore400Error1Value;

    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3InsightsItemsListingQualityScore500Error1> _v3InsightsItemsListingQualityScore500Error1Value;

    private GetListingQualityScoreError(Optional<V3InsightsItemsListingQualityScore400Error1> v3InsightsItemsListingQualityScore400Error1Value,
        Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3InsightsItemsListingQualityScore500Error1> v3InsightsItemsListingQualityScore500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3InsightsItemsListingQualityScore400Error1Value = v3InsightsItemsListingQualityScore400Error1Value;
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3InsightsItemsListingQualityScore500Error1Value = v3InsightsItemsListingQualityScore500Error1Value;
    }

    private static GetListingQualityScoreError AsV3InsightsItemsListingQualityScore400Error1(V3InsightsItemsListingQualityScore400Error1 value) =>
        new(Optional<V3InsightsItemsListingQualityScore400Error1>.Some(value), default, default, default);

    private static GetListingQualityScoreError AsV3Token400Error1(V3Token400Error1 value) =>
        new(default, Optional<V3Token400Error1>.Some(value), default, default);

    private static GetListingQualityScoreError AsV3InsightsItemsListingQualityScore500Error1(V3InsightsItemsListingQualityScore500Error1 value) =>
        new(default, default, Optional<V3InsightsItemsListingQualityScore500Error1>.Some(value), default);

    private static GetListingQualityScoreError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3InsightsItemsListingQualityScore400Error1(out V3InsightsItemsListingQualityScore400Error1 value) =>
        _v3InsightsItemsListingQualityScore400Error1Value.TryGetValue(out value);

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsListingQualityScore500Error1(out V3InsightsItemsListingQualityScore500Error1 value) =>
        _v3InsightsItemsListingQualityScore500Error1Value.TryGetValue(out value);

    private static Task<GetListingQualityScoreError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3InsightsItemsListingQualityScore400Error1>().As(
                AsV3InsightsItemsListingQualityScore400Error1),
            401 or 403 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            500 => response.Json<V3InsightsItemsListingQualityScore500Error1>().As(
                AsV3InsightsItemsListingQualityScore500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetListingQualityScoreError> Response { get; } = new(Create);
}
