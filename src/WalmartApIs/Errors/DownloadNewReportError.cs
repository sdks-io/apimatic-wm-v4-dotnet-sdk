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

    private static DownloadNewReportError AsErrorList(ErrorList value) => new(Optional<ErrorList>.Some(value), default);

    private static DownloadNewReportError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    private static Task<DownloadNewReportError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 404 or 500 => response.Json<ErrorList>().As(AsErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<DownloadNewReportError> Response { get; } = new(Create);
}
