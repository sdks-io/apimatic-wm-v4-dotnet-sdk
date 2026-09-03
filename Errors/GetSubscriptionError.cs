using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class GetSubscriptionError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetSubscriptionError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetSubscriptionError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetSubscriptionError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetSubscriptionError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetSubscriptionErrorResponse : IErrorResponse<GetSubscriptionError>
{
    public static GetSubscriptionErrorResponse Instance { get; } = new();

    private GetSubscriptionErrorResponse()
    {
    }

    public Task<GetSubscriptionError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetSubscriptionError.Create(response, ct);
}
