using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetShipmentError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private GetShipmentError(Optional<CommonErrorList> commonErrorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static GetShipmentError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static GetShipmentError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<GetShipmentError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetShipmentErrorResponse : IErrorResponse<GetShipmentError>
{
    public static GetShipmentErrorResponse Instance { get; } = new();

    private GetShipmentErrorResponse()
    {
    }

    public Task<GetShipmentError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetShipmentError.Create(response, ct);
}
