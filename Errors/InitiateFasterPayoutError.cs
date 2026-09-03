using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class InitiateFasterPayoutError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private InitiateFasterPayoutError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static InitiateFasterPayoutError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static InitiateFasterPayoutError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<InitiateFasterPayoutError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 409 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class InitiateFasterPayoutErrorResponse : IErrorResponse<InitiateFasterPayoutError>
{
    public static InitiateFasterPayoutErrorResponse Instance { get; } = new();

    private InitiateFasterPayoutErrorResponse()
    {
    }

    public Task<InitiateFasterPayoutError> Map(HttpResponseMessage response, CancellationToken ct) =>
        InitiateFasterPayoutError.Create(response, ct);
}
