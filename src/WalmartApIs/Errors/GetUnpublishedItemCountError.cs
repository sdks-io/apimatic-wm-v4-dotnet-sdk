using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetUnpublishedItemCountError : ApiError
{
    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3InsightsItemsUnpublishedCounts500Error1> _v3InsightsItemsUnpublishedCounts500Error1Value;

    private GetUnpublishedItemCountError(Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3InsightsItemsUnpublishedCounts500Error1> v3InsightsItemsUnpublishedCounts500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3InsightsItemsUnpublishedCounts500Error1Value = v3InsightsItemsUnpublishedCounts500Error1Value;
    }

    private static GetUnpublishedItemCountError AsV3Token400Error1(V3Token400Error1 value) =>
        new(Optional<V3Token400Error1>.Some(value), default, default);

    private static GetUnpublishedItemCountError AsV3InsightsItemsUnpublishedCounts500Error1(V3InsightsItemsUnpublishedCounts500Error1 value) =>
        new(default, Optional<V3InsightsItemsUnpublishedCounts500Error1>.Some(value), default);

    private static GetUnpublishedItemCountError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsUnpublishedCounts500Error1(out V3InsightsItemsUnpublishedCounts500Error1 value) =>
        _v3InsightsItemsUnpublishedCounts500Error1Value.TryGetValue(out value);

    private static Task<GetUnpublishedItemCountError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            401 or 403 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            500 => response.Json<V3InsightsItemsUnpublishedCounts500Error1>().As(
                AsV3InsightsItemsUnpublishedCounts500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetUnpublishedItemCountError> Response { get; } = new(Create);
}
