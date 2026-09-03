using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class CreateDestinationError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateDestinationError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateDestinationError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateDestinationError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateDestinationError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateDestinationErrorResponse : IErrorResponse<CreateDestinationError>
{
    public static CreateDestinationErrorResponse Instance { get; } = new();

    private CreateDestinationErrorResponse()
    {
    }

    public Task<CreateDestinationError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateDestinationError.Create(response, ct);
}
