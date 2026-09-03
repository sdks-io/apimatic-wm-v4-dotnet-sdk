using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class SearchListingsItemsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private SearchListingsItemsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static SearchListingsItemsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static SearchListingsItemsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<SearchListingsItemsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchListingsItemsErrorResponse : IErrorResponse<SearchListingsItemsError>
{
    public static SearchListingsItemsErrorResponse Instance { get; } = new();

    private SearchListingsItemsErrorResponse()
    {
    }

    public Task<SearchListingsItemsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchListingsItemsError.Create(response, ct);
}
