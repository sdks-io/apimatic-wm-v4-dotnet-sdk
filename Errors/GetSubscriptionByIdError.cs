using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class GetSubscriptionByIdError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private GetSubscriptionByIdError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static GetSubscriptionByIdError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static GetSubscriptionByIdError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<GetSubscriptionByIdError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetSubscriptionByIdErrorResponse : IErrorResponse<GetSubscriptionByIdError>
{
    public static GetSubscriptionByIdErrorResponse Instance { get; } = new();

    private GetSubscriptionByIdErrorResponse()
    {
    }

    public Task<GetSubscriptionByIdError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetSubscriptionByIdError.Create(response, ct);
}
