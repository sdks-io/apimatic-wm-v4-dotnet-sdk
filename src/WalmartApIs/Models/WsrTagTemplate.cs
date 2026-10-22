using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

/// <summary>
/// A tag template containing URL pattern with placeholders for affiliate tracking.
/// </summary>
public record WsrTagTemplate
{
    /// <summary>
    /// The type of page this template is for (For example, <c>ITEM</c>, <c>BRANDSHOP</c>).
    /// <para>
    /// &lt;span style="color:green"&gt;<b>Market availability: Global</b>&lt;/span&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("pageType")]
    public required PageType PageType { get; init; }

    /// <summary>
    /// The URL template with placeholders. Placeholders include <c>{insertCampaignId}</c>, <c>{insertAdGroupId}</c>, <c>{insertCreativeId}</c>, <c>{insertItemId}</c>, and <c>{insertBrandshopId}</c> which should be replaced with actual values when constructing the final referral URL.
    /// <para>
    /// &lt;span style="color:green"&gt;<b>Market availability: Global</b>&lt;/span&gt;
    /// </para>
    /// </summary>
    [JsonPropertyName("template")]
    public required string Template { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
