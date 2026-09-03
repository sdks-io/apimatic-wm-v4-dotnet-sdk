using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class PatchListingsItemError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private PatchListingsItemError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static PatchListingsItemError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static PatchListingsItemError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<PatchListingsItemError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class PatchListingsItemErrorResponse : IErrorResponse<PatchListingsItemError>
{
    public static PatchListingsItemErrorResponse Instance { get; } = new();

    private PatchListingsItemErrorResponse()
    {
    }

    public Task<PatchListingsItemError> Map(HttpResponseMessage response, CancellationToken ct) =>
        PatchListingsItemError.Create(response, ct);
}
