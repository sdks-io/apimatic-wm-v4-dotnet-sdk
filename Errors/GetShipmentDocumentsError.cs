using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetShipmentDocumentsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetShipmentDocumentsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetShipmentDocumentsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetShipmentDocumentsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetShipmentDocumentsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetShipmentDocumentsErrorResponse : IErrorResponse<GetShipmentDocumentsError>
{
    public static GetShipmentDocumentsErrorResponse Instance { get; } = new();

    private GetShipmentDocumentsErrorResponse()
    {
    }

    public Task<GetShipmentDocumentsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetShipmentDocumentsError.Create(response, ct);
}
