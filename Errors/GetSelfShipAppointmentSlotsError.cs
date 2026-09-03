using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetSelfShipAppointmentSlotsError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private GetSelfShipAppointmentSlotsError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static GetSelfShipAppointmentSlotsError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static GetSelfShipAppointmentSlotsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<GetSelfShipAppointmentSlotsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetSelfShipAppointmentSlotsErrorResponse : IErrorResponse<GetSelfShipAppointmentSlotsError>
{
    public static GetSelfShipAppointmentSlotsErrorResponse Instance { get; } = new();

    private GetSelfShipAppointmentSlotsErrorResponse()
    {
    }

    public Task<GetSelfShipAppointmentSlotsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetSelfShipAppointmentSlotsError.Create(response, ct);
}
