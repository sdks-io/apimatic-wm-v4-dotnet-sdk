using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetShipment2Error : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetShipment2Error(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetShipment2Error AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetShipment2Error AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetShipment2Error> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetShipment2ErrorResponse : IErrorResponse<GetShipment2Error>
{
    public static GetShipment2ErrorResponse Instance { get; } = new();

    private GetShipment2ErrorResponse()
    {
    }

    public Task<GetShipment2Error> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetShipment2Error.Create(response, ct);
}
