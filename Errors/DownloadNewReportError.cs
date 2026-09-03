using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DownloadNewReportError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private DownloadNewReportError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static DownloadNewReportError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static DownloadNewReportError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<DownloadNewReportError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadNewReportErrorResponse : IErrorResponse<DownloadNewReportError>
{
    public static DownloadNewReportErrorResponse Instance { get; } = new();

    private DownloadNewReportErrorResponse()
    {
    }

    public Task<DownloadNewReportError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadNewReportError.Create(response, ct);
}
