using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetUnpublishedItemsError : ApiError
{
    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3InsightsItemsUnpublishedItems500Error1> _v3InsightsItemsUnpublishedItems500Error1Value;

    private GetUnpublishedItemsError(Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3InsightsItemsUnpublishedItems500Error1> v3InsightsItemsUnpublishedItems500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3InsightsItemsUnpublishedItems500Error1Value = v3InsightsItemsUnpublishedItems500Error1Value;
    }

    private static GetUnpublishedItemsError AsV3Token400Error1(V3Token400Error1 value) =>
        new(Optional<V3Token400Error1>.Some(value), default, default);

    private static GetUnpublishedItemsError AsV3InsightsItemsUnpublishedItems500Error1(V3InsightsItemsUnpublishedItems500Error1 value) =>
        new(default, Optional<V3InsightsItemsUnpublishedItems500Error1>.Some(value), default);

    private static GetUnpublishedItemsError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsItemsUnpublishedItems500Error1(out V3InsightsItemsUnpublishedItems500Error1 value) =>
        _v3InsightsItemsUnpublishedItems500Error1Value.TryGetValue(out value);

    private static Task<GetUnpublishedItemsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 401 or 403 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            500 => response.Json<V3InsightsItemsUnpublishedItems500Error1>().As(
                AsV3InsightsItemsUnpublishedItems500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetUnpublishedItemsError> Response { get; } = new(Create);
}
