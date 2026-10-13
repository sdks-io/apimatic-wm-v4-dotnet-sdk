using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class GetDestinationsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetDestinationsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetDestinationsError AsNoContent(RawError value) => new(Optional<RawError>.Some(value), default);

    private static GetDestinationsError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    private static Task<GetDestinationsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.RawBody().As(AsNoContent),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetDestinationsError> Response { get; } = new(Create);
}
