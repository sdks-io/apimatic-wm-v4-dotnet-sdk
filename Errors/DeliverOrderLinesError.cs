using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DeliverOrderLinesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private DeliverOrderLinesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static DeliverOrderLinesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static DeliverOrderLinesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<DeliverOrderLinesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeliverOrderLinesErrorResponse : IErrorResponse<DeliverOrderLinesError>
{
    public static DeliverOrderLinesErrorResponse Instance { get; } = new();

    private DeliverOrderLinesErrorResponse()
    {
    }

    public Task<DeliverOrderLinesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeliverOrderLinesError.Create(response, ct);
}
