using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateFeedError : ApiError
{
    private readonly Optional<ErrorList1> _errorList1Value;

    private CreateFeedError(Optional<ErrorList1> errorList1Value, Optional<RawError> fallback) : base(fallback)
    {
        _errorList1Value = errorList1Value;
    }

    private static CreateFeedError AsErrorList1(ErrorList1 value) =>
        new(Optional<ErrorList1>.Some(value), default);

    private static CreateFeedError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList1(out ErrorList1 value) => _errorList1Value.TryGetValue(out value);

    internal static Task<CreateFeedError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 429 or 500 => FromJson<ErrorList1>(response, ct).As(AsErrorList1),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateFeedErrorResponse : IErrorResponse<CreateFeedError>
{
    public static CreateFeedErrorResponse Instance { get; } = new();

    private CreateFeedErrorResponse()
    {
    }

    public Task<CreateFeedError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateFeedError.Create(response, ct);
}
