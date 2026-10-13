using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DeliverOrderLinesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private DeliverOrderLinesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static DeliverOrderLinesError AsErrorList(ErrorList value) => new(Optional<ErrorList>.Some(value), default);

    private static DeliverOrderLinesError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    private static Task<DeliverOrderLinesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => response.Json<ErrorList>().As(AsErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<DeliverOrderLinesError> Response { get; } = new(Create);
}
