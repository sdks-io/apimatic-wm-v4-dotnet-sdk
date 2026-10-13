using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class GetSubscriptionByIdError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetSubscriptionByIdError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetSubscriptionByIdError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static GetSubscriptionByIdError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    private static Task<GetSubscriptionByIdError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.RawBody().As(AsNoContent),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetSubscriptionByIdError> Response { get; } = new(Create);
}
