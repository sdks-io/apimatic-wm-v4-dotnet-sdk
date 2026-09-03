using System.Net.Http;
using System.Threading;
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

    private static PurchaseShipmentError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static PurchaseShipmentError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<PurchaseShipmentError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class PurchaseShipmentErrorResponse : IErrorResponse<PurchaseShipmentError>
{
    public static PurchaseShipmentErrorResponse Instance { get; } = new();

    private PurchaseShipmentErrorResponse()
    {
    }

    public Task<PurchaseShipmentError> Map(HttpResponseMessage response, CancellationToken ct) =>
        PurchaseShipmentError.Create(response, ct);
}
