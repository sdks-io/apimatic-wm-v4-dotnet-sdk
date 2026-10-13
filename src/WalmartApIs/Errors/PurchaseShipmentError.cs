using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class PurchaseShipmentError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private PurchaseShipmentError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static PurchaseShipmentError AsErrorList(ErrorList value) => new(Optional<ErrorList>.Some(value), default);

    private static PurchaseShipmentError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    private static Task<PurchaseShipmentError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.Json<ErrorList>().As(AsErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<PurchaseShipmentError> Response { get; } = new(Create);
}
