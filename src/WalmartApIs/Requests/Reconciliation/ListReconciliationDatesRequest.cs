using System.ComponentModel.DataAnnotations;

namespace WalmartApIs.Requests.Reconciliation;

/// <summary>
/// The inputs of the ListReconciliationDates operation.
/// </summary>
public sealed record ListReconciliationDatesRequest
{
    /// <summary>
    /// Numeric partner/seller ID
    /// </summary>
    [RegularExpression("^[0-9]{1,50}$")]
    public required string PartnerId { get; init; }
}
