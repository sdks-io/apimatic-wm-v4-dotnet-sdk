using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CancelReportScheduleError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CancelReportScheduleError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CancelReportScheduleError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CancelReportScheduleError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CancelReportScheduleError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CancelReportScheduleErrorResponse : IErrorResponse<CancelReportScheduleError>
{
    public static CancelReportScheduleErrorResponse Instance { get; } = new();

    private CancelReportScheduleErrorResponse()
    {
    }

    public Task<CancelReportScheduleError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CancelReportScheduleError.Create(response, ct);
}
