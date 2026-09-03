using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetPricingError : ApiError
{
    private readonly Optional<IReadOnlyList<Error3>> _listOfError3Value;

    private GetPricingError(Optional<IReadOnlyList<Error3>> listOfError3Value, Optional<RawError> fallback) : base(fallback)
    {
        _listOfError3Value = listOfError3Value;
    }

    private static GetPricingError AsListOfError3(IReadOnlyList<Error3> value) =>
        new(Optional<IReadOnlyList<Error3>>.Some(value), default);

    private static GetPricingError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetListOfError3(out IReadOnlyList<Error3> value) =>
        _listOfError3Value.TryGetValue(out value);

    internal static Task<GetPricingError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<IReadOnlyList<Error3>>(response, ct).As(AsListOfError3),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetPricingErrorResponse : IErrorResponse<GetPricingError>
{
    public static GetPricingErrorResponse Instance { get; } = new();

    private GetPricingErrorResponse()
    {
    }

    public Task<GetPricingError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetPricingError.Create(response, ct);
}
