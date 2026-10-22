using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class WalmartPlusEnrollmentError : ApiError
{
    private readonly Optional<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1> _v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1Value;

    private readonly Optional<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1> _v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1Value;

    private WalmartPlusEnrollmentError(Optional<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1> v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1Value,
        Optional<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1> v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1Value =
            v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1Value;
        _v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1Value =
            v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1Value;
    }

    private static WalmartPlusEnrollmentError AsV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1(V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1 value) =>
        new(Optional<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1>.Some(value), default, default);

    private static WalmartPlusEnrollmentError AsV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1(V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1 value) =>
        new(default, Optional<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1>.Some(value), default);

    private static WalmartPlusEnrollmentError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1(out V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1 value) =>
        _v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1Value.TryGetValue(out value);

    public bool TryGetV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1(out V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1 value) =>
        _v3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1Value.TryGetValue(out value);

    private static Task<WalmartPlusEnrollmentError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1>().As(
                AsV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff400Error1),
            500 => response.Json<V3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1>().As(
                AsV3FeedsFeedTypeProgramActionsRequestTypeWalmartPlusSff500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<WalmartPlusEnrollmentError> Response { get; } = new(Create);
}
