using WalmartApIs.Models;

namespace WalmartApIs.Requests.Authorization;

/// <summary>
/// The inputs of the RegisterClient operation.
/// </summary>
public sealed record RegisterClientRequest
{
    public required ClientRegistrationRequest Body { get; init; }
}
