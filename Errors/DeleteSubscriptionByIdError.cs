using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Errors;

public sealed class DeleteSubscriptionByIdError : ApiError
{
    private readonly Optional<RawError> _noContentValue;

    private DeleteSubscriptionByIdError(Optional<RawError> noContentValue, Optional<RawError> fallback) : base(fallback)
    {
        _noContentValue = noContentValue;
    }

    private static DeleteSubscriptionByIdError AsNoContent(RawError value) =>
        new(Optional<RawError>.Some(value), default);

    private static DeleteSubscriptionByIdError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetNoContent(out RawError value) => _noContentValue.TryGetValue(out value);

    internal static Task<DeleteSubscriptionByIdError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromRawBody(response, ct).As(AsNoContent),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DeleteSubscriptionByIdErrorResponse : IErrorResponse<DeleteSubscriptionByIdError>
{
    public static DeleteSubscriptionByIdErrorResponse Instance { get; } = new();

    private DeleteSubscriptionByIdErrorResponse()
    {
    }

    public Task<DeleteSubscriptionByIdError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DeleteSubscriptionByIdError.Create(response, ct);
}
