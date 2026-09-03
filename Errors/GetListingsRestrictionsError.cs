using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetListingsRestrictionsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetListingsRestrictionsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetListingsRestrictionsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetListingsRestrictionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetListingsRestrictionsError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetListingsRestrictionsErrorResponse : IErrorResponse<GetListingsRestrictionsError>
{
    public static GetListingsRestrictionsErrorResponse Instance { get; } = new();

    private GetListingsRestrictionsErrorResponse()
    {
    }

    public Task<GetListingsRestrictionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetListingsRestrictionsError.Create(response, ct);
}
