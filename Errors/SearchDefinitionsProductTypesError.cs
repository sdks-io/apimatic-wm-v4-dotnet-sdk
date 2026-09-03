using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class SearchDefinitionsProductTypesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private SearchDefinitionsProductTypesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static SearchDefinitionsProductTypesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static SearchDefinitionsProductTypesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<SearchDefinitionsProductTypesError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SearchDefinitionsProductTypesErrorResponse : IErrorResponse<SearchDefinitionsProductTypesError>
{
    public static SearchDefinitionsProductTypesErrorResponse Instance { get; } = new();

    private SearchDefinitionsProductTypesErrorResponse()
    {
    }

    public Task<SearchDefinitionsProductTypesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SearchDefinitionsProductTypesError.Create(response, ct);
}
