using System.Collections.Generic;
using System.Threading.Tasks;
using WalmartApIs.Core.ErrorResponse;
using WalmartApIs.Core.Models;
using WalmartApIs.Models;

namespace WalmartApIs.Errors;

public sealed class DiscardLabelError : ApiError
{
    private readonly Optional<IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1>> _listOfV3ShippingLabelsCarriersTrackings400Error1Value;

    private DiscardLabelError(Optional<IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1>> listOfV3ShippingLabelsCarriersTrackings400Error1Value,
        Optional<RawError> fallback) : base(fallback)
    {
        _listOfV3ShippingLabelsCarriersTrackings400Error1Value = listOfV3ShippingLabelsCarriersTrackings400Error1Value;
    }

    private static DiscardLabelError AsListOfV3ShippingLabelsCarriersTrackings400Error1(IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1> value) =>
        new(Optional<IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1>>.Some(value), default);

    private static DiscardLabelError AsFallback(RawError value) => new(default, Optional<RawError>.Some(value));

    public bool TryGetListOfV3ShippingLabelsCarriersTrackings400Error1(out IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1> value) =>
        _listOfV3ShippingLabelsCarriersTrackings400Error1Value.TryGetValue(out value);

    private static Task<DiscardLabelError> Create(FailedResponse response) =>
        response.StatusCode switch
        {
            400 => response.Json<IReadOnlyList<V3ShippingLabelsCarriersTrackings400Error1>>().As(
                AsListOfV3ShippingLabelsCarriersTrackings400Error1),
            _ => response.RawBody().As(AsFallback)
        };

    internal static ApiErrorResponse<DiscardLabelError> Response { get; } = new(Create);
}
