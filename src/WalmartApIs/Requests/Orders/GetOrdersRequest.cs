using System;
using System.Collections.Generic;
using WalmartApIs.Core.Validation.Attributes;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Orders;

/// <summary>
/// The inputs of the GetOrders operation.
/// </summary>
public sealed record GetOrdersRequest
{
    /// <summary>
    /// Filter orders created after this date-time (ISO 8601).
    /// <para>
    /// <b>the roadmap — not yet supported.</b> Sending this parameter today
    /// returns <c>400 FILTER_NOT_SUPPORTED</c>; the Orders service does not
    /// accept date-range filters at the order level. Tracked by
    /// .
    /// Retained in the contract so SDKs generated today stay
    /// forward-compatible.
    /// </para>
    /// </summary>
    public DateTimeOffset? CreatedAfter { get; init; }

    /// <summary>
    /// Filter orders created before this date-time (ISO 8601).
    /// <para>
    /// <b>the roadmap — not yet supported.</b> See <c>createdAfter</c> for the
    /// rationale and the tracking ticket.
    /// </para>
    /// </summary>
    public DateTimeOffset? CreatedBefore { get; init; }

    /// <summary>
    /// Filter orders updated after this date-time (ISO 8601).
    /// <para>
    /// <b>the roadmap — not yet supported.</b> Sending this parameter today
    /// returns <c>400 FILTER_NOT_SUPPORTED</c>; the Orders service has no
    /// order-level update-date index. Tracked by
    /// .
    /// </para>
    /// </summary>
    public DateTimeOffset? LastUpdatedAfter { get; init; }

    /// <summary>
    /// Filter by order status.
    /// <para>
    /// <b>the roadmap limitation:</b> the Orders service accepts AT MOST ONE
    /// status per call. Passing multiple values today returns `400
    /// FILTER_NOT_SUPPORTED`; pass a single value or omit to match all.
    /// Multi-status fan-out tracked by
    /// .
    /// </para>
    /// </summary>
    public IReadOnlyList<OrderStatus>? OrderStatuses { get; init; }

    /// <summary>
    /// Filter by fulfillment type.
    /// <para>
    /// <b>the roadmap — not yet supported.</b> Sending this parameter today
    /// returns <c>400 FILTER_NOT_SUPPORTED</c>; the underlying service accepts one
    /// shipNodeType per call and multi-type fan-out is Phase 2. Tracked
    /// by .
    /// </para>
    /// </summary>
    public IReadOnlyList<FulfillmentType>? FulfillmentTypes { get; init; }

    [Minimum(1)]
    [Maximum(200)]
    public int PageSize { get; init; } = 100;

    public string? NextToken { get; init; }
}
