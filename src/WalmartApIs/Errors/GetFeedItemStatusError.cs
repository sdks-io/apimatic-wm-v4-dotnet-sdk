using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetFeedItemStatusError : ApiError
{
    private readonly Optional<V3Feeds404Error21> _v3Feeds404Error21Value;

    private readonly Optional<V3Feeds500Error21> _v3Feeds500Error21Value;

    private GetFeedItemStatusError(Optional<V3Feeds404Error21> v3Feeds404Error21Value,
        Optional<V3Feeds500Error21> v3Feeds500Error21Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3Feeds404Error21Value = v3Feeds404Error21Value;
        _v3Feeds500Error21Value = v3Feeds500Error21Value;
    }

    private static GetFeedItemStatusError AsV3Feeds404Error21(V3Feeds404Error21 value) =>
        new(Optional<V3Feeds404Error21>.Some(value), default, default);

    private static GetFeedItemStatusError AsV3Feeds500Error21(V3Feeds500Error21 value) =>
        new(default, Optional<V3Feeds500Error21>.Some(value), default);

    private static GetFeedItemStatusError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3Feeds404Error21(out V3Feeds404Error21 value) => _v3Feeds404Error21Value.TryGetValue(out value);

    public bool TryGetV3Feeds500Error21(out V3Feeds500Error21 value) => _v3Feeds500Error21Value.TryGetValue(out value);

    private static Task<GetFeedItemStatusError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 => response.Json<V3Feeds404Error21>().As(AsV3Feeds404Error21),
            500 => response.Json<V3Feeds500Error21>().As(AsV3Feeds500Error21),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetFeedItemStatusError> Response { get; } = new(Create);
}
