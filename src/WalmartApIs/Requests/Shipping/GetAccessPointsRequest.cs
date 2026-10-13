using System.ComponentModel.DataAnnotations;

namespace WalmartApIs.Requests.Shipping;

/// <summary>
/// The inputs of the GetAccessPoints operation.
/// </summary>
public sealed record GetAccessPointsRequest
{
    /// <summary>
    /// Comma-separated list of access point types to include.
    /// </summary>
    public required string AccessPointTypes { get; init; }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code (e.g. US, CA, MX).
    /// </summary>
    [StringLength(2, MinimumLength = 2)]
    public required string CountryCode { get; init; }

    /// <summary>
    /// Postal code to search around.
    /// </summary>
    public required string PostalCode { get; init; }
}
