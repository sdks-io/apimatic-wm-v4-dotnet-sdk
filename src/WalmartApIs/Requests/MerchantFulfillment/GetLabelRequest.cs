using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.MerchantFulfillment;

/// <summary>
/// The inputs of the GetLabel operation.
/// </summary>
public sealed record GetLabelRequest
{
    public required string ShipmentId { get; init; }

    public Format Format { get; init; } = Format.Pdf;
}
