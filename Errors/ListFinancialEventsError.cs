using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ListFinancialEventsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private ListFinancialEventsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static ListFinancialEventsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static ListFinancialEventsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<ListFinancialEventsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ListFinancialEventsErrorResponse : IErrorResponse<ListFinancialEventsError>
{
    public static ListFinancialEventsErrorResponse Instance { get; } = new();

    private ListFinancialEventsErrorResponse()
    {
    }

    public Task<ListFinancialEventsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ListFinancialEventsError.Create(response, ct);
}
