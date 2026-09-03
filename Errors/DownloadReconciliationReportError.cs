using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DownloadReconciliationReportError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private DownloadReconciliationReportError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static DownloadReconciliationReportError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static DownloadReconciliationReportError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<DownloadReconciliationReportError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 404 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class DownloadReconciliationReportErrorResponse : IErrorResponse<DownloadReconciliationReportError>
{
    public static DownloadReconciliationReportErrorResponse Instance { get; } = new();

    private DownloadReconciliationReportErrorResponse()
    {
    }

    public Task<DownloadReconciliationReportError> Map(HttpResponseMessage response, CancellationToken ct) =>
        DownloadReconciliationReportError.Create(response, ct);
}
