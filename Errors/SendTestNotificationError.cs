using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class SendTestNotificationError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private SendTestNotificationError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static SendTestNotificationError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static SendTestNotificationError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<SendTestNotificationError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class SendTestNotificationErrorResponse : IErrorResponse<SendTestNotificationError>
{
    public static SendTestNotificationErrorResponse Instance { get; } = new();

    private SendTestNotificationErrorResponse()
    {
    }

    public Task<SendTestNotificationError> Map(HttpResponseMessage response, CancellationToken ct) =>
        SendTestNotificationError.Create(response, ct);
}
