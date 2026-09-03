using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class SearchTransactionsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private SearchTransactionsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static SearchTransactionsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static SearchTransactionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<SearchTransactionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchTransactionsErrorResponse : IErrorResponse<SearchTransactionsError>
{
    public static SearchTransactionsErrorResponse Instance { get; } = new();

    private SearchTransactionsErrorResponse()
    {
    }

    public Task<SearchTransactionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchTransactionsError.Create(response, ct);
}
