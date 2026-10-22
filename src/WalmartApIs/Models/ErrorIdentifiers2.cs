using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// error Identifiers.
/// <para>
/// &lt;b style="color: green;"&gt;Market availability: CL only&lt;/b&gt;
/// </para>
/// </summary>
public record ErrorIdentifiers2
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("entry")]
    public IReadOnlyList<object>? Entry { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
