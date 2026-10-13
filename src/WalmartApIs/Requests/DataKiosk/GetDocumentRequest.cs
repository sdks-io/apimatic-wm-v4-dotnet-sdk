namespace WalmartApIs.Requests.DataKiosk;

/// <summary>
/// The inputs of the GetDocument operation.
/// </summary>
public sealed record GetDocumentRequest
{
    public required string DocumentId { get; init; }
}
