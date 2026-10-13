namespace WalmartApIs.Requests.Notifications;

/// <summary>
/// The inputs of the GetSubscription operation.
/// </summary>
public sealed record GetSubscriptionRequest
{
    /// <summary>
    /// The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH.
    /// </summary>
    public required string NotificationType { get; init; }

    /// <summary>
    /// The version of the payload object to be used in the notification.
    /// </summary>
    public string? PayloadVersion { get; init; }
}
