using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateFinalPayoutCaseStatusError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private UpdateFinalPayoutCaseStatusError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static UpdateFinalPayoutCaseStatusError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static UpdateFinalPayoutCaseStatusError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<UpdateFinalPayoutCaseStatusError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 404 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdateFinalPayoutCaseStatusErrorResponse : IErrorResponse<UpdateFinalPayoutCaseStatusError>
{
    public static UpdateFinalPayoutCaseStatusErrorResponse Instance { get; } = new();

    private UpdateFinalPayoutCaseStatusErrorResponse()
    {
    }

    public Task<UpdateFinalPayoutCaseStatusError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdateFinalPayoutCaseStatusError.Create(response, ct);
}
