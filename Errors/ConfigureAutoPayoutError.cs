using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class ConfigureAutoPayoutError : ApiError
{
    private readonly Optional<ErrorList> _errorListValue;

    private ConfigureAutoPayoutError(Optional<ErrorList> errorListValue, Optional<RawError> fallback) : base(fallback)
    {
        _errorListValue = errorListValue;
    }

    private static ConfigureAutoPayoutError AsErrorList(ErrorList value) =>
        new(Optional<ErrorList>.Some(value), default);

    private static ConfigureAutoPayoutError AsFallback(RawError value) =>
        new(default, Optional<RawError>.Some(value));

    public bool TryGetErrorList(out ErrorList value) => _errorListValue.TryGetValue(out value);

    internal static Task<ConfigureAutoPayoutError> Create(HttpResponseMessage response, CancellationToken ct) =>
        (int)response.StatusCode switch
        {
            400 or 401 or 500 => FromJson<ErrorList>(response, ct).As(AsErrorList),
            _ => FromRawBody(response, ct).As(AsFallback)
        };
}

internal sealed class ConfigureAutoPayoutErrorResponse : IErrorResponse<ConfigureAutoPayoutError>
{
    public static ConfigureAutoPayoutErrorResponse Instance { get; } = new();

    private ConfigureAutoPayoutErrorResponse()
    {
    }

    public Task<ConfigureAutoPayoutError> Map(HttpResponseMessage response, CancellationToken ct) =>
        ConfigureAutoPayoutError.Create(response, ct);
}
