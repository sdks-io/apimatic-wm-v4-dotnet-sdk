using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class CreateSubscriptionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private CreateSubscriptionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static CreateSubscriptionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static CreateSubscriptionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<CreateSubscriptionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateSubscriptionErrorResponse : IErrorResponse<CreateSubscriptionError>
{
    public static CreateSubscriptionErrorResponse Instance { get; } = new();

    private CreateSubscriptionErrorResponse()
    {
    }

    public Task<CreateSubscriptionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateSubscriptionError.Create(response, ct);
}
