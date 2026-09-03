using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetFasterPayoutEligibilityError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetFasterPayoutEligibilityError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetFasterPayoutEligibilityError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetFasterPayoutEligibilityError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetFasterPayoutEligibilityError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetFasterPayoutEligibilityErrorResponse : IErrorResponse<GetFasterPayoutEligibilityError>
{
    public static GetFasterPayoutEligibilityErrorResponse Instance { get; } = new();

    private GetFasterPayoutEligibilityErrorResponse()
    {
    }

    public Task<GetFasterPayoutEligibilityError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetFasterPayoutEligibilityError.Create(response, ct);
}
