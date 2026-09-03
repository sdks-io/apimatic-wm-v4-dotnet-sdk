using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CheckDownloadReportByPeriodError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CheckDownloadReportByPeriodError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CheckDownloadReportByPeriodError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CheckDownloadReportByPeriodError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CheckDownloadReportByPeriodError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CheckDownloadReportByPeriodErrorResponse : IErrorResponse<CheckDownloadReportByPeriodError>
{
    public static CheckDownloadReportByPeriodErrorResponse Instance { get; } = new();

    private CheckDownloadReportByPeriodErrorResponse()
    {
    }

    public Task<CheckDownloadReportByPeriodError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CheckDownloadReportByPeriodError.Create(response, ct);
}
