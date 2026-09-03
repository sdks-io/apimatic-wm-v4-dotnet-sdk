using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetEligibleShippingServicesError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetEligibleShippingServicesError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetEligibleShippingServicesError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetEligibleShippingServicesError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetEligibleShippingServicesError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetEligibleShippingServicesErrorResponse : IErrorResponse<GetEligibleShippingServicesError>
{
    public static GetEligibleShippingServicesErrorResponse Instance { get; } = new();

    private GetEligibleShippingServicesErrorResponse()
    {
    }

    public Task<GetEligibleShippingServicesError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetEligibleShippingServicesError.Create(response, ct);
}
