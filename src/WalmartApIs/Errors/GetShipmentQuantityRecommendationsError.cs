using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetShipmentQuantityRecommendationsError : ApiError
{
    private readonly Optional<ErrorResponse2> _errorResponse2Value;

    private readonly Optional<NotFoundResponse> _notFoundResponseValue;

    private GetShipmentQuantityRecommendationsError(Optional<ErrorResponse2> errorResponse2Value,
        Optional<NotFoundResponse> notFoundResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _errorResponse2Value = errorResponse2Value;
        _notFoundResponseValue = notFoundResponseValue;
    }

    private static GetShipmentQuantityRecommendationsError AsErrorResponse2(ErrorResponse2 value) =>
        new(Optional<ErrorResponse2>.Some(value), default, default);

    private static GetShipmentQuantityRecommendationsError AsNotFoundResponse(NotFoundResponse value) =>
        new(default, Optional<NotFoundResponse>.Some(value), default);

    private static GetShipmentQuantityRecommendationsError AsFallback(RawError value) =>
        new(default, default, Optional<RawError>.Some(value));

    public bool TryGetErrorResponse2(out ErrorResponse2 value) => _errorResponse2Value.TryGetValue(out value);

    public bool TryGetNotFoundResponse(out NotFoundResponse value) => _notFoundResponseValue.TryGetValue(out value);

    private static Task<GetShipmentQuantityRecommendationsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<ErrorResponse2>().As(AsErrorResponse2),
            404 => response.Json<NotFoundResponse>().As(AsNotFoundResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetShipmentQuantityRecommendationsError> Response { get; } = new(Create);
}
