using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class PostStatusError : ApiError
{
    private readonly Optional<V3ItemsDisputeDuplicatesStatus403Error1> _v3ItemsDisputeDuplicatesStatus403Error1Value;

    private readonly Optional<V3ItemsDisputeDuplicatesStatus404Error1> _v3ItemsDisputeDuplicatesStatus404Error1Value;

    private readonly Optional<V3ItemsDisputeDuplicatesStatus500Error1> _v3ItemsDisputeDuplicatesStatus500Error1Value;

    private PostStatusError(Optional<V3ItemsDisputeDuplicatesStatus403Error1> v3ItemsDisputeDuplicatesStatus403Error1Value,
        Optional<V3ItemsDisputeDuplicatesStatus404Error1> v3ItemsDisputeDuplicatesStatus404Error1Value,
        Optional<V3ItemsDisputeDuplicatesStatus500Error1> v3ItemsDisputeDuplicatesStatus500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ItemsDisputeDuplicatesStatus403Error1Value = v3ItemsDisputeDuplicatesStatus403Error1Value;
        _v3ItemsDisputeDuplicatesStatus404Error1Value = v3ItemsDisputeDuplicatesStatus404Error1Value;
        _v3ItemsDisputeDuplicatesStatus500Error1Value = v3ItemsDisputeDuplicatesStatus500Error1Value;
    }

    private static PostStatusError AsV3ItemsDisputeDuplicatesStatus403Error1(V3ItemsDisputeDuplicatesStatus403Error1 value) =>
        new(Optional<V3ItemsDisputeDuplicatesStatus403Error1>.Some(value), default, default, default);

    private static PostStatusError AsV3ItemsDisputeDuplicatesStatus404Error1(V3ItemsDisputeDuplicatesStatus404Error1 value) =>
        new(default, Optional<V3ItemsDisputeDuplicatesStatus404Error1>.Some(value), default, default);

    private static PostStatusError AsV3ItemsDisputeDuplicatesStatus500Error1(V3ItemsDisputeDuplicatesStatus500Error1 value) =>
        new(default, default, Optional<V3ItemsDisputeDuplicatesStatus500Error1>.Some(value), default);

    private static PostStatusError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3ItemsDisputeDuplicatesStatus403Error1(out V3ItemsDisputeDuplicatesStatus403Error1 value) =>
        _v3ItemsDisputeDuplicatesStatus403Error1Value.TryGetValue(out value);

    public bool TryGetV3ItemsDisputeDuplicatesStatus404Error1(out V3ItemsDisputeDuplicatesStatus404Error1 value) =>
        _v3ItemsDisputeDuplicatesStatus404Error1Value.TryGetValue(out value);

    public bool TryGetV3ItemsDisputeDuplicatesStatus500Error1(out V3ItemsDisputeDuplicatesStatus500Error1 value) =>
        _v3ItemsDisputeDuplicatesStatus500Error1Value.TryGetValue(out value);

    private static Task<PostStatusError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            403 => response.Json<V3ItemsDisputeDuplicatesStatus403Error1>().As(
                AsV3ItemsDisputeDuplicatesStatus403Error1),
            404 => response.Json<V3ItemsDisputeDuplicatesStatus404Error1>().As(
                AsV3ItemsDisputeDuplicatesStatus404Error1),
            500 => response.Json<V3ItemsDisputeDuplicatesStatus500Error1>().As(
                AsV3ItemsDisputeDuplicatesStatus500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<PostStatusError> Response { get; } = new(Create);
}
