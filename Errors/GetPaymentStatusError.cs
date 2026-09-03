using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetPaymentStatusError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetPaymentStatusError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetPaymentStatusError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetPaymentStatusError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetPaymentStatusError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetPaymentStatusErrorResponse : IErrorResponse<GetPaymentStatusError>
{
    public static GetPaymentStatusErrorResponse Instance { get; } = new();

    private GetPaymentStatusErrorResponse()
    {
    }

    public Task<GetPaymentStatusError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetPaymentStatusError.Create(response, ct);
}
