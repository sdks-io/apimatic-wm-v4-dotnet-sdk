using System.Collections.Generic;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Requests.Uploads;

/// <summary>
/// The inputs of the CreateUploadDestinationForResource operation.
/// </summary>
public sealed record CreateUploadDestinationForResourceRequest
{
    /// <summary>
    /// The resource type for the upload destination (e.g. feeds)
    /// </summary>
    public required Resource Resource { get; init; }

    /// <summary>
    /// MIME type of the content to be uploaded
    /// </summary>
    public required ContentType1 ContentType { get; init; }

    public required IReadOnlyList<string> MarketplaceIds { get; init; }

    /// <summary>
    /// MD5 hash of the content to be uploaded, encoded as base64
    /// </summary>
    public required string ContentMd5 { get; init; }
}
