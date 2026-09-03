using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateItemComplianceDetailsError : ApiError
{
    private readonly Optional<CommonErrorList> _commonErrorListValue;

    private UpdateItemComplianceDetailsError(Optional<CommonErrorList> commonErrorListValue,
        Optional<RawError> fallback) : base(fallback)
    {
        _commonErrorListValue = commonErrorListValue;
    }

    private static UpdateItemComplianceDetailsError AsCommonErrorList(CommonErrorList value) =>
        new(Optional<CommonErrorList>.Some(value), default);

    private static UpdateItemComplianceDetailsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetCommonErrorList(out CommonErrorList value) =>
        _commonErrorListValue.TryGetValue(out value);

    internal static Task<UpdateItemComplianceDetailsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<CommonErrorList>(response, ct).As(AsCommonErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdateItemComplianceDetailsErrorResponse : IErrorResponse<UpdateItemComplianceDetailsError>
{
    public static UpdateItemComplianceDetailsErrorResponse Instance { get; } = new();

    private UpdateItemComplianceDetailsErrorResponse()
    {
    }

    public Task<UpdateItemComplianceDetailsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdateItemComplianceDetailsError.Create(response, ct);
}
