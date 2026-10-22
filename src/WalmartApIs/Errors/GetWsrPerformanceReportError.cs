using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetWsrPerformanceReportError : ApiError
{
    private readonly Optional<WsrErrorResponse> _wsrErrorResponseValue;

    private GetWsrPerformanceReportError(Optional<WsrErrorResponse> wsrErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _wsrErrorResponseValue = wsrErrorResponseValue;
    }

    private static GetWsrPerformanceReportError AsWsrErrorResponse(WsrErrorResponse value) =>
        new(Optional<WsrErrorResponse>.Some(value), default);

    private static GetWsrPerformanceReportError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetWsrErrorResponse(out WsrErrorResponse value) => _wsrErrorResponseValue.TryGetValue(out value);

    private static Task<GetWsrPerformanceReportError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<WsrErrorResponse>().As(AsWsrErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetWsrPerformanceReportError> Response { get; } = new(Create);
}
