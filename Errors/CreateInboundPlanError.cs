using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateInboundPlanError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private CreateInboundPlanError(Optional<CommonErrorList> commonErrorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static CreateInboundPlanError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static CreateInboundPlanError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<CreateInboundPlanError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateInboundPlanErrorResponse : IErrorResponse<CreateInboundPlanError>
{
    public static CreateInboundPlanErrorResponse Instance { get; } = new();

    private CreateInboundPlanErrorResponse()
    {
    }

    public Task<CreateInboundPlanError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateInboundPlanError.Create(response, ct);
}
