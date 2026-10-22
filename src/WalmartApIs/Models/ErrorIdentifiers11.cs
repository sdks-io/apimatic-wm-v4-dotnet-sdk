using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// error Identifiers.
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: US | CA | MX&lt;/b&gt;
/// </para>
/// </summary>
public record ErrorIdentifiers11
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("entry")]
    public IReadOnlyList<object>? Entry { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
