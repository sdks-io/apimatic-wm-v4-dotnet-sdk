namespace WalmartApIs.Requests.Finances;

/// <summary>
/// The inputs of the ListFinancialEventsByOrderId operation.
/// </summary>
public sealed record ListFinancialEventsByOrderIdRequest
{
    /// <summary>
    /// Walmart order number — must be numeric (1–50 digits).
    /// </summary>
    public required string OrderId { get; init; }

    /// <summary>
    /// Ignored — GMP returns all commission entries in one page.
    /// </summary>
    public int? MaxResultsPerPage { get; init; }

    /// <summary>
    /// Not supported — returns 400 Bad Request if supplied.
    /// </summary>
    public string? NextToken { get; init; }
}
