using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetAccountError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetAccountError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetAccountError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetAccountError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetAccountError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetAccountErrorResponse : IErrorResponse<GetAccountError>
{
    public static GetAccountErrorResponse Instance { get; } = new();

    private GetAccountErrorResponse()
    {
    }

    public Task<GetAccountError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetAccountError.Create(response, ct);
}
