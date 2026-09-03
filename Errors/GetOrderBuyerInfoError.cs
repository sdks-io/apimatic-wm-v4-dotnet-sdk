using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetOrderBuyerInfoError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetOrderBuyerInfoError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetOrderBuyerInfoError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetOrderBuyerInfoError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetOrderBuyerInfoError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetOrderBuyerInfoErrorResponse : IErrorResponse<GetOrderBuyerInfoError>
{
    public static GetOrderBuyerInfoErrorResponse Instance { get; } = new();

    private GetOrderBuyerInfoErrorResponse()
    {
    }

    public Task<GetOrderBuyerInfoError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetOrderBuyerInfoError.Create(response, ct);
}
