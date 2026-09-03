using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class UpdateVerificationStatusError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private UpdateVerificationStatusError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static UpdateVerificationStatusError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static UpdateVerificationStatusError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<UpdateVerificationStatusError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 or 503 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class UpdateVerificationStatusErrorResponse : IErrorResponse<UpdateVerificationStatusError>
{
    public static UpdateVerificationStatusErrorResponse Instance { get; } = new();

    private UpdateVerificationStatusErrorResponse()
    {
    }

    public Task<UpdateVerificationStatusError> Map(HttpResponseMessage response, CancellationToken ct) =>
        UpdateVerificationStatusError.Create(response, ct);
}
