using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetMarketplaceParticipationsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetMarketplaceParticipationsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetMarketplaceParticipationsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetMarketplaceParticipationsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetMarketplaceParticipationsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetMarketplaceParticipationsErrorResponse : IErrorResponse<GetMarketplaceParticipationsError>
{
    public static GetMarketplaceParticipationsErrorResponse Instance { get; } = new();

    private GetMarketplaceParticipationsErrorResponse()
    {
    }

    public Task<GetMarketplaceParticipationsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetMarketplaceParticipationsError.Create(response, ct);
}
