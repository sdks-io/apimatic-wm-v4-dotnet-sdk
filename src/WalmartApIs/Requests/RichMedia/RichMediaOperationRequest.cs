using WalmartApIs.Models;

namespace WalmartApIs.Requests.RichMedia;

/// <summary>
/// The inputs of the RichMediaOperation operation.
/// </summary>
public sealed record RichMediaOperationRequest
{
    /// <summary>
    /// A unique ID that identifies each API call and is used to track and debug issues. Use a randomly generated GUID for this ID.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmQosCorrelationId { get; init; }

    /// <summary>
    /// Specifies the name of the Walmart service being called.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public required string WmSvcName { get; init; }

    /// <summary>
    /// A unique ID to identify the consumer request by channel. Use the consumer channel type received during onboarding.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    public string? WmConsumerChannelType { get; init; }

    /// <summary>
    /// Rich media feed payload containing asset metadata, item associations, and media URLs.
    /// </summary>
    public required RichMediaFeedRequest Body { get; init; }
}
