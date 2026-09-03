using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ConfirmDeliveryWindowOptionsError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private ConfirmDeliveryWindowOptionsError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static ConfirmDeliveryWindowOptionsError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static ConfirmDeliveryWindowOptionsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<ConfirmDeliveryWindowOptionsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ConfirmDeliveryWindowOptionsErrorResponse : IErrorResponse<ConfirmDeliveryWindowOptionsError>
{
    public static ConfirmDeliveryWindowOptionsErrorResponse Instance { get; } = new();

    private ConfirmDeliveryWindowOptionsErrorResponse()
    {
    }

    public Task<ConfirmDeliveryWindowOptionsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ConfirmDeliveryWindowOptionsError.Create(response, ct);
}
