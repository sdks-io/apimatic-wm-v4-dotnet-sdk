using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using WalmartApIs.Core.Hooks;

namespace WalmartApIs.Core;

public sealed record RequestOptions
{
    public LogLevel? LogLevel { get; init; }

    public IReadOnlyList<SdkHook>? Hooks { get; init; }
}
