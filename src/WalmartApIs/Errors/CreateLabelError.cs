using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class CreateLabelError : ApiError
{
    private readonly Optional<V3ShippingLabels500Error1> _v3ShippingLabels500Error1Value;

    private CreateLabelError(Optional<V3ShippingLabels500Error1> v3ShippingLabels500Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _v3ShippingLabels500Error1Value = v3ShippingLabels500Error1Value;
    }

    private static CreateLabelError AsV3ShippingLabels500Error1(V3ShippingLabels500Error1 value) =>
        new(Optional<V3ShippingLabels500Error1>.Some(value), default);

    private static CreateLabelError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetV3ShippingLabels500Error1(out V3ShippingLabels500Error1 value) =>
        _v3ShippingLabels500Error1Value.TryGetValue(out value);

    private static Task<CreateLabelError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            500 => response.Json<V3ShippingLabels500Error1>().As(AsV3ShippingLabels500Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<CreateLabelError> Response { get; } = new(Create);
}
