namespace WalmartApIs.Requests.Notifications;

/// <summary>
/// The inputs of the SendTestNotification operation.
/// </summary>
public sealed record SendTestNotificationRequest
{
    /// <summary>
    /// The type of notification. Must be one of: EMAIL, WEBHOOKS, SMS, PULL, MOBILE_PUSH.
    /// </summary>
    public required string NotificationType { get; init; }

    public required object Body { get; init; }
}
