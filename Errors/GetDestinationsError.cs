using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class GetDestinationsError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetDestinationsError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetDestinationsError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetDestinationsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetDestinationsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetDestinationsErrorResponse : IErrorResponse<GetDestinationsError>
{
    public static GetDestinationsErrorResponse Instance { get; } = new();

    private GetDestinationsErrorResponse()
    {
    }

    public Task<GetDestinationsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetDestinationsError.Create(response, ct);
}
