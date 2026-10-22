using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

/// <summary>
/// Carrier package type details.
/// </summary>
public record Data8
{
    /// <summary>
    /// The carrier package Id
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The carrier package short name
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packageTypeShortName")]
    public string? PackageTypeShortName { get; init; }

    /// <summary>
    /// The carrier package display name
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("packageTypeDisplayName")]
    public string? PackageTypeDisplayName { get; init; }

    /// <summary>
    /// The package length. The Unit is determined by dimensionUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("length")]
    public double? Length { get; init; }

    /// <summary>
    /// The package width. The Unit is determined by dimensionUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("width")]
    public double? Width { get; init; }

    /// <summary>
    /// The package height. The Unit is determined by dimensionUnit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("height")]
    public double? Height { get; init; }

    /// <summary>
    /// The package dimension unit.
    /// <para>
    /// &lt;b style="color: green;"&gt;Market availability: Global&lt;/b&gt;
    /// </para>
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("dimensionUnit")]
    public string? DimensionUnit { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
