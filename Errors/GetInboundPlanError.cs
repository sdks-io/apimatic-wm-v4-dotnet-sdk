using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetInboundPlanError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private GetInboundPlanError(Optional<CommonErrorList> commonErrorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static GetInboundPlanError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static GetInboundPlanError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<GetInboundPlanError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetInboundPlanErrorResponse : IErrorResponse<GetInboundPlanError>
{
    public static GetInboundPlanErrorResponse Instance { get; } = new();

    private GetInboundPlanErrorResponse()
    {
    }

    public Task<GetInboundPlanError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetInboundPlanError.Create(response, ct);
}
