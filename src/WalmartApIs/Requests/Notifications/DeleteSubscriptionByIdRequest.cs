namespace WalmartApIs.Requests.Notifications;

/// <summary>
/// The inputs of the DeleteSubscriptionById operation.
/// </summary>
public sealed record DeleteSubscriptionByIdRequest
{
    /// <summary>
    /// The identifier for the subscription that you want to delete.
    /// </summary>
    public required string SubscriptionId { get; init; }

    /// <summary>
    /// The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH.
    /// </summary>
    public required string NotificationType { get; init; }
}
