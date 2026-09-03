using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetFulfillmentOrderError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetFulfillmentOrderError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetFulfillmentOrderError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetFulfillmentOrderError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetFulfillmentOrderError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFulfillmentOrderErrorResponse : IErrorResponse<GetFulfillmentOrderError>
{
    public static GetFulfillmentOrderErrorResponse Instance { get; } = new();

    private GetFulfillmentOrderErrorResponse()
    {
    }

    public Task<GetFulfillmentOrderError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFulfillmentOrderError.Create(response, ct);
}
