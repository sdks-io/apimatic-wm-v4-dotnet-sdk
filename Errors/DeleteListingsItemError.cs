using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DeleteListingsItemError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private DeleteListingsItemError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static DeleteListingsItemError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static DeleteListingsItemError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<DeleteListingsItemError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteListingsItemErrorResponse : IErrorResponse<DeleteListingsItemError>
{
    public static DeleteListingsItemErrorResponse Instance { get; } = new();

    private DeleteListingsItemErrorResponse()
    {
    }

    public Task<DeleteListingsItemError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteListingsItemError.Create(response, ct);
}
