using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DownloadOldReportError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private DownloadOldReportError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static DownloadOldReportError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static DownloadOldReportError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<DownloadOldReportError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadOldReportErrorResponse : IErrorResponse<DownloadOldReportError>
{
    public static DownloadOldReportErrorResponse Instance { get; } = new();

    private DownloadOldReportErrorResponse()
    {
    }

    public Task<DownloadOldReportError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadOldReportError.Create(response, ct);
}
