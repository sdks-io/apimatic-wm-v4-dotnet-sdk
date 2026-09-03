using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetTrackingError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetTrackingError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetTrackingError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetTrackingError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetTrackingError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetTrackingErrorResponse : IErrorResponse<GetTrackingError>
{
    public static GetTrackingErrorResponse Instance { get; } = new();

    private GetTrackingErrorResponse()
    {
    }

    public Task<GetTrackingError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetTrackingError.Create(response, ct);
}
