using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CancelFulfillmentOrderError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CancelFulfillmentOrderError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CancelFulfillmentOrderError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CancelFulfillmentOrderError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CancelFulfillmentOrderError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CancelFulfillmentOrderErrorResponse : IErrorResponse<CancelFulfillmentOrderError>
{
    public static CancelFulfillmentOrderErrorResponse Instance { get; } = new();

    private CancelFulfillmentOrderErrorResponse()
    {
    }

    public Task<CancelFulfillmentOrderError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CancelFulfillmentOrderError.Create(response, ct);
}
