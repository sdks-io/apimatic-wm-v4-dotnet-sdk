using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetFeedsError : ApiError
{
    private readonly Optional<ErrorList1> _errorList1Value;

    private GetFeedsError(Optional<ErrorList1> errorList1Value, Optional<RawError> fallback) : base(fallback)
    {
        _errorList1Value = errorList1Value;
    }

    private static GetFeedsError AsErrorList1(ErrorList1 value) => new(Optional<ErrorList1>.Some(value), default);

    private static GetFeedsError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList1(out ErrorList1 value) => _errorList1Value.TryGetValue(out value);

    private static Task<GetFeedsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 429 or 500 => response.Json<ErrorList1>().As(AsErrorList1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetFeedsError> Response { get; } = new(Create);
}
