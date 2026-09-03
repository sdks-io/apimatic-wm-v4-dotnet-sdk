using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetReportSchedulesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetReportSchedulesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetReportSchedulesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetReportSchedulesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetReportSchedulesError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetReportSchedulesErrorResponse : IErrorResponse<GetReportSchedulesError>
{
    public static GetReportSchedulesErrorResponse Instance { get; } = new();

    private GetReportSchedulesErrorResponse()
    {
    }

    public Task<GetReportSchedulesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetReportSchedulesError.Create(response, ct);
}
