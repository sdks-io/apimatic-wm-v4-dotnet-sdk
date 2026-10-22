using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DownloadClaimDocumentsError : ApiError
{
    private readonly Optional<V3ClaimsShipmentProtectionClaimDocuments400Error1> _v3ClaimsShipmentProtectionClaimDocuments400Error1Value;

    private readonly Optional<V3ClaimsShipmentProtectionClaimDocuments404Error1> _v3ClaimsShipmentProtectionClaimDocuments404Error1Value;

    private readonly Optional<V3ClaimsShipmentProtectionClaimDocuments500Error1> _v3ClaimsShipmentProtectionClaimDocuments500Error1Value;

    private DownloadClaimDocumentsError(Optional<V3ClaimsShipmentProtectionClaimDocuments400Error1> v3ClaimsShipmentProtectionClaimDocuments400Error1Value,
        Optional<V3ClaimsShipmentProtectionClaimDocuments404Error1> v3ClaimsShipmentProtectionClaimDocuments404Error1Value,
        Optional<V3ClaimsShipmentProtectionClaimDocuments500Error1> v3ClaimsShipmentProtectionClaimDocuments500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ClaimsShipmentProtectionClaimDocuments400Error1Value =
            v3ClaimsShipmentProtectionClaimDocuments400Error1Value;
        _v3ClaimsShipmentProtectionClaimDocuments404Error1Value =
            v3ClaimsShipmentProtectionClaimDocuments404Error1Value;
        _v3ClaimsShipmentProtectionClaimDocuments500Error1Value =
            v3ClaimsShipmentProtectionClaimDocuments500Error1Value;
    }

    private static DownloadClaimDocumentsError AsV3ClaimsShipmentProtectionClaimDocuments400Error1(V3ClaimsShipmentProtectionClaimDocuments400Error1 value) =>
        new(Optional<V3ClaimsShipmentProtectionClaimDocuments400Error1>.Some(value), default, default, default);

    private static DownloadClaimDocumentsError AsV3ClaimsShipmentProtectionClaimDocuments404Error1(V3ClaimsShipmentProtectionClaimDocuments404Error1 value) =>
        new(default, Optional<V3ClaimsShipmentProtectionClaimDocuments404Error1>.Some(value), default, default);

    private static DownloadClaimDocumentsError AsV3ClaimsShipmentProtectionClaimDocuments500Error1(V3ClaimsShipmentProtectionClaimDocuments500Error1 value) =>
        new(default, default, Optional<V3ClaimsShipmentProtectionClaimDocuments500Error1>.Some(value), default);

    private static DownloadClaimDocumentsError AsFallback(RawError value) =>
        new(default, default, default, Optional<RawError>.Some(value));

    public bool TryGetV3ClaimsShipmentProtectionClaimDocuments400Error1(out V3ClaimsShipmentProtectionClaimDocuments400Error1 value) =>
        _v3ClaimsShipmentProtectionClaimDocuments400Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtectionClaimDocuments404Error1(out V3ClaimsShipmentProtectionClaimDocuments404Error1 value) =>
        _v3ClaimsShipmentProtectionClaimDocuments404Error1Value.TryGetValue(out value);

    public bool TryGetV3ClaimsShipmentProtectionClaimDocuments500Error1(out V3ClaimsShipmentProtectionClaimDocuments500Error1 value) =>
        _v3ClaimsShipmentProtectionClaimDocuments500Error1Value.TryGetValue(out value);

    private static Task<DownloadClaimDocumentsError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<V3ClaimsShipmentProtectionClaimDocuments400Error1>().As(
                AsV3ClaimsShipmentProtectionClaimDocuments400Error1),
            404 => response.Json<V3ClaimsShipmentProtectionClaimDocuments404Error1>().As(
                AsV3ClaimsShipmentProtectionClaimDocuments404Error1),
            500 => response.Json<V3ClaimsShipmentProtectionClaimDocuments500Error1>().As(
                AsV3ClaimsShipmentProtectionClaimDocuments500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<DownloadClaimDocumentsError> Response { get; } = new(Create);
}
