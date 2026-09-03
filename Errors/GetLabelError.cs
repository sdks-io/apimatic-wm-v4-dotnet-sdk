using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class GetLabelError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private GetLabelError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static GetLabelError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static GetLabelError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<GetLabelError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class GetLabelErrorResponse : IErrorResponse<GetLabelError>
{
    public static GetLabelErrorResponse Instance { get; } = new();

    private GetLabelErrorResponse()
    {
    }

    public Task<GetLabelError> Map(HttpResponseMessage response, CancellationToken ct) =>
        GetLabelError.Create(response, ct);
}
