using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetRatesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetRatesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetRatesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetRatesError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetRatesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetRatesErrorResponse : IErrorResponse<GetRatesError>
{
    public static GetRatesErrorResponse Instance { get; } = new();

    private GetRatesErrorResponse()
    {
    }

    public Task<GetRatesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetRatesError.Create(response, ct);
}
