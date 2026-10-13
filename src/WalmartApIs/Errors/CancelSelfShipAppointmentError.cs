using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CancelSelfShipAppointmentError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private CancelSelfShipAppointmentError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static CancelSelfShipAppointmentError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static CancelSelfShipAppointmentError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) => _commonErrorListValue.TryGetValue(out value);

    private static Task<CancelSelfShipAppointmentError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => response.Json<CommonErrorList>().As(AsCommonErrorList),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CancelSelfShipAppointmentError> Response { get; } = new(Create);
}
