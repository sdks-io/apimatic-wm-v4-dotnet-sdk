using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CancelShipment2Error : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CancelShipment2Error(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CancelShipment2Error AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CancelShipment2Error AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CancelShipment2Error> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CancelShipment2ErrorResponse : IErrorResponse<CancelShipment2Error>
{
    public static CancelShipment2ErrorResponse Instance { get; } = new();

    private CancelShipment2ErrorResponse()
    {
    }

    public Task<CancelShipment2Error> Map(HttpResponseMessage response, CancellationToken ct) =>
        CancelShipment2Error.Create(response, ct);
}
