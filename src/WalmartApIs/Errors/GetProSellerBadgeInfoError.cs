using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetProSellerBadgeInfoError : ApiError
{
    private readonly Optional<V3InsightsProsellerbadge400Error1> _v3InsightsProsellerbadge400Error1Value;

    private readonly Optional<V3Token400Error1> _v3Token400Error1Value;

    private readonly Optional<V3InsightsProsellerbadge500Error1> _v3InsightsProsellerbadge500Error1Value;

    private GetProSellerBadgeInfoError(Optional<V3InsightsProsellerbadge400Error1> v3InsightsProsellerbadge400Error1Value,
        Optional<V3Token400Error1> v3Token400Error1Value,
        Optional<V3InsightsProsellerbadge500Error1> v3InsightsProsellerbadge500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3InsightsProsellerbadge400Error1Value = v3InsightsProsellerbadge400Error1Value;
        _v3Token400Error1Value = v3Token400Error1Value;
        _v3InsightsProsellerbadge500Error1Value = v3InsightsProsellerbadge500Error1Value;
    }

    private static GetProSellerBadgeInfoError AsV3InsightsProsellerbadge400Error1(V3InsightsProsellerbadge400Error1 value) =>
        new(Optional<V3InsightsProsellerbadge400Error1>.Some(value), default, default, default);

    private static GetProSellerBadgeInfoError AsV3Token400Error1(V3Token400Error1 value) =>
        new(default, Optional<V3Token400Error1>.Some(value), default, default);

    private static GetProSellerBadgeInfoError AsV3InsightsProsellerbadge500Error1(V3InsightsProsellerbadge500Error1 value) =>
        new(default, default, Optional<V3InsightsProsellerbadge500Error1>.Some(value), default);

    private static GetProSellerBadgeInfoError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3InsightsProsellerbadge400Error1(out V3InsightsProsellerbadge400Error1 value) =>
        _v3InsightsProsellerbadge400Error1Value.TryGetValue(out value);

    public bool TryGetV3Token400Error1(out V3Token400Error1 value) => _v3Token400Error1Value.TryGetValue(out value);

    public bool TryGetV3InsightsProsellerbadge500Error1(out V3InsightsProsellerbadge500Error1 value) =>
        _v3InsightsProsellerbadge500Error1Value.TryGetValue(out value);

    private static Task<GetProSellerBadgeInfoError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3InsightsProsellerbadge400Error1>().As(AsV3InsightsProsellerbadge400Error1),
            401 or 403 => response.Json<V3Token400Error1>().As(AsV3Token400Error1),
            500 => response.Json<V3InsightsProsellerbadge500Error1>().As(AsV3InsightsProsellerbadge500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetProSellerBadgeInfoError> Response { get; } = new(Create);
}
