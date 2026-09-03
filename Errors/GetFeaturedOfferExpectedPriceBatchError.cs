using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetFeaturedOfferExpectedPriceBatchError : ApiError
{
    private readonly Optional<IReadOnlyList<Error3>> _listOfError3Value;

    private GetFeaturedOfferExpectedPriceBatchError(Optional<IReadOnlyList<Error3>> listOfError3Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _listOfError3Value = listOfError3Value;
    }

    private static GetFeaturedOfferExpectedPriceBatchError AsListOfError3(IReadOnlyList<Error3> value) =>
        new(Optional<IReadOnlyList<Error3>>.Some(value), default);

    private static GetFeaturedOfferExpectedPriceBatchError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetListOfError3(out IReadOnlyList<Error3> value) =>
        _listOfError3Value.TryGetValue(out value);

    internal static Task<GetFeaturedOfferExpectedPriceBatchError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<IReadOnlyList<Error3>>(response, ct).As(AsListOfError3),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFeaturedOfferExpectedPriceBatchErrorResponse : IErrorResponse<GetFeaturedOfferExpectedPriceBatchError>
{
    public static GetFeaturedOfferExpectedPriceBatchErrorResponse Instance { get; } = new();

    private GetFeaturedOfferExpectedPriceBatchErrorResponse()
    {
    }

    public Task<GetFeaturedOfferExpectedPriceBatchError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFeaturedOfferExpectedPriceBatchError.Create(response, ct);
}
