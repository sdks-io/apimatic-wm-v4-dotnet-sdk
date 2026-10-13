using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetInboundPlanError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private GetInboundPlanError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static GetInboundPlanError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static GetInboundPlanError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) => _commonErrorListValue.TryGetValue(out value);

    private static Task<GetInboundPlanError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.Json<CommonErrorList>().As(AsCommonErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<GetInboundPlanError> Response { get; } = new(Create);
}
