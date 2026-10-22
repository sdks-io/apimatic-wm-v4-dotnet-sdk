using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetRestockRecommendationsError : ApiError
{
    private readonly Optional<ErrorResponse2> _errorResponse2Value;

    private GetRestockRecommendationsError(Optional<ErrorResponse2> errorResponse2Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorResponse2Value = errorResponse2Value;
    }

    private static GetRestockRecommendationsError AsErrorResponse2(ErrorResponse2 value) =>
        new(Optional<ErrorResponse2>.Some(value), default);

    private static GetRestockRecommendationsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorResponse2(out ErrorResponse2 value) => _errorResponse2Value.TryGetValue(out value);

    private static Task<GetRestockRecommendationsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<ErrorResponse2>().As(AsErrorResponse2),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetRestockRecommendationsError> Response { get; } = new(Create);
}
