using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ShipOrderMultiPackageError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private ShipOrderMultiPackageError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static ShipOrderMultiPackageError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static ShipOrderMultiPackageError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    private static Task<ShipOrderMultiPackageError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => response.Json<ErrorList>().As(AsErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<ShipOrderMultiPackageError> Response { get; } = new(Create);
}
