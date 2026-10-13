using System;

namespace WalmartApIs.Requests.FulfillmentOutbound;

/// <summary>
/// The inputs of the ListAllFulfillmentOrders operation.
/// </summary>
public sealed record ListAllFulfillmentOrdersRequest
{
    public DateTimeOffset? QueryStartDate { get; init; }

    public string? NextToken { get; init; }
}
