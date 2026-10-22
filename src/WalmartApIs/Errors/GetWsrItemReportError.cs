using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetWsrItemReportError : ApiError
{
    private readonly Optional<WsrErrorResponse> _wsrErrorResponseValue;

    private GetWsrItemReportError(Optional<WsrErrorResponse> wsrErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _wsrErrorResponseValue = wsrErrorResponseValue;
    }

    private static GetWsrItemReportError AsWsrErrorResponse(WsrErrorResponse value) =>
        new(Optional<WsrErrorResponse>.Some(value), default);

    private static GetWsrItemReportError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetWsrErrorResponse(out WsrErrorResponse value) => _wsrErrorResponseValue.TryGetValue(out value);

    private static Task<GetWsrItemReportError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<WsrErrorResponse>().As(AsWsrErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetWsrItemReportError> Response { get; } = new(Create);
}
