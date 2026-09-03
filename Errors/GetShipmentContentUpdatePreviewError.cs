using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetShipmentContentUpdatePreviewError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private GetShipmentContentUpdatePreviewError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static GetShipmentContentUpdatePreviewError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static GetShipmentContentUpdatePreviewError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<GetShipmentContentUpdatePreviewError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetShipmentContentUpdatePreviewErrorResponse : IErrorResponse<GetShipmentContentUpdatePreviewError>
{
    public static GetShipmentContentUpdatePreviewErrorResponse Instance { get; } = new();

    private GetShipmentContentUpdatePreviewErrorResponse()
    {
    }

    public Task<GetShipmentContentUpdatePreviewError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetShipmentContentUpdatePreviewError.Create(response, ct);
}
