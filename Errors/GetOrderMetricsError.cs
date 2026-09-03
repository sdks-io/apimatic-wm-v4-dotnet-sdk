using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetOrderMetricsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetOrderMetricsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetOrderMetricsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetOrderMetricsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetOrderMetricsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetOrderMetricsErrorResponse : IErrorResponse<GetOrderMetricsError>
{
    public static GetOrderMetricsErrorResponse Instance { get; } = new();

    private GetOrderMetricsErrorResponse()
    {
    }

    public Task<GetOrderMetricsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetOrderMetricsError.Create(response, ct);
}
