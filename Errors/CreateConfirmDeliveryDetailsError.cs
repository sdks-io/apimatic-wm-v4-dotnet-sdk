using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateConfirmDeliveryDetailsError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private CreateConfirmDeliveryDetailsError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static CreateConfirmDeliveryDetailsError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static CreateConfirmDeliveryDetailsError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<CreateConfirmDeliveryDetailsError> Create(HttpResponseMessage response,
        CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 403 or 404 or 429 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class CreateConfirmDeliveryDetailsErrorResponse : IErrorResponse<CreateConfirmDeliveryDetailsError>
{
    public static CreateConfirmDeliveryDetailsErrorResponse Instance { get; } = new();

    private CreateConfirmDeliveryDetailsErrorResponse()
    {
    }

    public Task<CreateConfirmDeliveryDetailsError> Map(HttpResponseMessage response, CancellationToken ct) =>
        CreateConfirmDeliveryDetailsError.Create(response, ct);
}
