using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class PostContestError : ApiError
{
    private readonly Optional<V3ItemsDisputeDuplicatesContest403Error1> _v3ItemsDisputeDuplicatesContest403Error1Value;

    private readonly Optional<V3ItemsDisputeDuplicatesContest404Error1> _v3ItemsDisputeDuplicatesContest404Error1Value;

    private readonly Optional<V3ItemsDisputeDuplicatesContest500Error1> _v3ItemsDisputeDuplicatesContest500Error1Value;

    private PostContestError(Optional<V3ItemsDisputeDuplicatesContest403Error1> v3ItemsDisputeDuplicatesContest403Error1Value,
        Optional<V3ItemsDisputeDuplicatesContest404Error1> v3ItemsDisputeDuplicatesContest404Error1Value,
        Optional<V3ItemsDisputeDuplicatesContest500Error1> v3ItemsDisputeDuplicatesContest500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ItemsDisputeDuplicatesContest403Error1Value = v3ItemsDisputeDuplicatesContest403Error1Value;
        _v3ItemsDisputeDuplicatesContest404Error1Value = v3ItemsDisputeDuplicatesContest404Error1Value;
        _v3ItemsDisputeDuplicatesContest500Error1Value = v3ItemsDisputeDuplicatesContest500Error1Value;
    }

    private static PostContestError AsV3ItemsDisputeDuplicatesContest403Error1(V3ItemsDisputeDuplicatesContest403Error1 value) =>
        new(Optional<V3ItemsDisputeDuplicatesContest403Error1>.Some(value), default, default, default);

    private static PostContestError AsV3ItemsDisputeDuplicatesContest404Error1(V3ItemsDisputeDuplicatesContest404Error1 value) =>
        new(default, Optional<V3ItemsDisputeDuplicatesContest404Error1>.Some(value), default, default);

    private static PostContestError AsV3ItemsDisputeDuplicatesContest500Error1(V3ItemsDisputeDuplicatesContest500Error1 value) =>
        new(default, default, Optional<V3ItemsDisputeDuplicatesContest500Error1>.Some(value), default);

    private static PostContestError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3ItemsDisputeDuplicatesContest403Error1(out V3ItemsDisputeDuplicatesContest403Error1 value) =>
        _v3ItemsDisputeDuplicatesContest403Error1Value.TryGetValue(out value);

    public bool TryGetV3ItemsDisputeDuplicatesContest404Error1(out V3ItemsDisputeDuplicatesContest404Error1 value) =>
        _v3ItemsDisputeDuplicatesContest404Error1Value.TryGetValue(out value);

    public bool TryGetV3ItemsDisputeDuplicatesContest500Error1(out V3ItemsDisputeDuplicatesContest500Error1 value) =>
        _v3ItemsDisputeDuplicatesContest500Error1Value.TryGetValue(out value);

    private static Task<PostContestError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 => response.Json<V3ItemsDisputeDuplicatesContest403Error1>().As(
                AsV3ItemsDisputeDuplicatesContest403Error1),
            404 => response.Json<V3ItemsDisputeDuplicatesContest404Error1>().As(
                AsV3ItemsDisputeDuplicatesContest404Error1),
            500 => response.Json<V3ItemsDisputeDuplicatesContest500Error1>().As(
                AsV3ItemsDisputeDuplicatesContest500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<PostContestError> Response { get; } = new(Create);
}
