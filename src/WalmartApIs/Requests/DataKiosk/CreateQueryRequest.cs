using WalmartApIs.Models;

namespace WalmartApIs.Requests.DataKiosk;

/// <summary>
/// The inputs of the CreateQuery operation.
/// </summary>
public sealed record CreateQueryRequest
{
    public required CreateQuerySpecification Body { get; init; }
}
