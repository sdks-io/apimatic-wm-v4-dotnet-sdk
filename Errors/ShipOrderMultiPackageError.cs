using System.Net.Http;
using System.Threading;
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

    internal static Task<ShipOrderMultiPackageError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ShipOrderMultiPackageErrorResponse : IErrorResponse<ShipOrderMultiPackageError>
{
    public static ShipOrderMultiPackageErrorResponse Instance { get; } = new();

    private ShipOrderMultiPackageErrorResponse()
    {
    }

    public Task<ShipOrderMultiPackageError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ShipOrderMultiPackageError.Create(response, ct);
}
