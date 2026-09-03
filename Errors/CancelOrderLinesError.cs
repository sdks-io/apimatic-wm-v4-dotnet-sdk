using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CancelOrderLinesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CancelOrderLinesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CancelOrderLinesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CancelOrderLinesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CancelOrderLinesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CancelOrderLinesErrorResponse : IErrorResponse<CancelOrderLinesError>
{
    public static CancelOrderLinesErrorResponse Instance { get; } = new();

    private CancelOrderLinesErrorResponse()
    {
    }

    public Task<CancelOrderLinesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CancelOrderLinesError.Create(response, ct);
}
