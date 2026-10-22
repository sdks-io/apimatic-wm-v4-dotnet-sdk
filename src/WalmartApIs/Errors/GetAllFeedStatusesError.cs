using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetAllFeedStatusesError : ApiError
{
    private readonly Optional<FeedRecordResponse> _feedRecordResponseValue;

    private GetAllFeedStatusesError(Optional<FeedRecordResponse> feedRecordResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _feedRecordResponseValue = feedRecordResponseValue;
    }

    private static GetAllFeedStatusesError AsFeedRecordResponse(FeedRecordResponse value) =>
        new(Optional<FeedRecordResponse>.Some(value), default);

    private static GetAllFeedStatusesError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetFeedRecordResponse(out FeedRecordResponse value) =>
        _feedRecordResponseValue.TryGetValue(out value);

    private static Task<GetAllFeedStatusesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            404 or 500 => response.Json<FeedRecordResponse>().As(AsFeedRecordResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetAllFeedStatusesError> Response { get; } = new(Create);
}
