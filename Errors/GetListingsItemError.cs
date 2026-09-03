using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetListingsItemError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetListingsItemError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetListingsItemError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetListingsItemError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetListingsItemError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetListingsItemErrorResponse : IErrorResponse<GetListingsItemError>
{
    public static GetListingsItemErrorResponse Instance { get; } = new();

    private GetListingsItemErrorResponse()
    {
    }

    public Task<GetListingsItemError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetListingsItemError.Create(response, ct);
}
