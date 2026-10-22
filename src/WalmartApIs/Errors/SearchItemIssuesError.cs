using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class SearchItemIssuesError : ApiError
{
    private readonly Optional<ErrorResponseModel> _errorResponseModelValue;

    private readonly Optional<ErrorResponse429> _errorResponse429Value;

    private SearchItemIssuesError(Optional<ErrorResponseModel> errorResponseModelValue,
        Optional<ErrorResponse429> errorResponse429Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorResponseModelValue = errorResponseModelValue;
        _errorResponse429Value = errorResponse429Value;
    }

    private static SearchItemIssuesError AsErrorResponseModel(ErrorResponseModel value) =>
        new(Optional<ErrorResponseModel>.Some(value), default, default);

    private static SearchItemIssuesError AsErrorResponse429(ErrorResponse429 value) =>
        new(default, Optional<ErrorResponse429>.Some(value), default);

    private static SearchItemIssuesError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorResponseModel(out ErrorResponseModel value) =>
        _errorResponseModelValue.TryGetValue(out value);

    public bool TryGetErrorResponse429(out ErrorResponse429 value) => _errorResponse429Value.TryGetValue(out value);

    private static Task<SearchItemIssuesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 401 or 403 or 422 or 500 or 503 => response.Json<ErrorResponseModel>().As(AsErrorResponseModel),
            429 => response.Json<ErrorResponse429>().As(AsErrorResponse429),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<SearchItemIssuesError> Response { get; } = new(Create);
}
