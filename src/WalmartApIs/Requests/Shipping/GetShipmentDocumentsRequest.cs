using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the GetShipmentDocuments operation.
/// </summary>
public sealed record GetShipmentDocumentsRequest
{
    /// <summary>
    /// Identifier of the shipment whose documents to retrieve.
    /// </summary>
    public required string ShipmentId { get; init; }

    /// <summary>
    /// Optional package-level reference id to retrieve documents
    /// for a specific package within a multi-package shipment.
    /// </summary>
    public string? PackageClientReferenceId { get; init; }

    /// <summary>
    /// Requested document format (defaults to PDF).
    /// </summary>
    public Format1? Format { get; init; }
}
