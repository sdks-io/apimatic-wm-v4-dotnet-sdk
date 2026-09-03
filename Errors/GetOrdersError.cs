using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetOrdersError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetOrdersError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetOrdersError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetOrdersError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetOrdersError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetOrdersErrorResponse : IErrorResponse<GetOrdersError>
{
    public static GetOrdersErrorResponse Instance { get; } = new();

    private GetOrdersErrorResponse()
    {
    }

    public Task<GetOrdersError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetOrdersError.Create(response, ct);
}
