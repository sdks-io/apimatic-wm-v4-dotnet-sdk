using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class PutListingsItemError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private PutListingsItemError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static PutListingsItemError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static PutListingsItemError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<PutListingsItemError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class PutListingsItemErrorResponse : IErrorResponse<PutListingsItemError>
{
    public static PutListingsItemErrorResponse Instance { get; } = new();

    private PutListingsItemErrorResponse()
    {
    }

    public Task<PutListingsItemError> Map(HttpResponseMessage response, CancellationToken ct) =>
        PutListingsItemError.Create(response, ct);
}
