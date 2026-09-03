using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetFinalPayoutCaseStatusError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetFinalPayoutCaseStatusError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetFinalPayoutCaseStatusError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetFinalPayoutCaseStatusError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetFinalPayoutCaseStatusError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 404 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFinalPayoutCaseStatusErrorResponse : IErrorResponse<GetFinalPayoutCaseStatusError>
{
    public static GetFinalPayoutCaseStatusErrorResponse Instance { get; } = new();

    private GetFinalPayoutCaseStatusErrorResponse()
    {
    }

    public Task<GetFinalPayoutCaseStatusError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFinalPayoutCaseStatusError.Create(response, ct);
}
