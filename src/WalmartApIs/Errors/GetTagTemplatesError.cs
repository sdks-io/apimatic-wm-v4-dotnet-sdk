using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetTagTemplatesError : ApiError
{
    private readonly Optional<WsrErrorResponse> _wsrErrorResponseValue;

    private GetTagTemplatesError(Optional<WsrErrorResponse> wsrErrorResponseValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _wsrErrorResponseValue = wsrErrorResponseValue;
    }

    private static GetTagTemplatesError AsWsrErrorResponse(WsrErrorResponse value) =>
        new(Optional<WsrErrorResponse>.Some(value), default);

    private static GetTagTemplatesError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetWsrErrorResponse(out WsrErrorResponse value) => _wsrErrorResponseValue.TryGetValue(out value);

    private static Task<GetTagTemplatesError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 500 => response.Json<WsrErrorResponse>().As(AsWsrErrorResponse),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetTagTemplatesError> Response { get; } = new(Create);
}
