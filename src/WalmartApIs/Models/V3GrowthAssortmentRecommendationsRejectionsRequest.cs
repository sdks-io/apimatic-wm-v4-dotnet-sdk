using System.Collections.Generic;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;
using WalmartApIs.Models.Enums;

namespace WalmartApIs.Models;

public record V3GrowthAssortmentRecommendationsRejectionsRequest
{
    /// <summary>
    /// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | ITEM | To reject list of recommended items | string |
    /// </para>
    /// </summary>
    [JsonPropertyName("recommendationType")]
    public string RecommendationType { get; } = "ITEM";

    /// <summary>
    /// Different type of filters can be passed in this object.&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("filterCriteria")]
    public FilterCriteria5? FilterCriteria { get; init; }

    /// <summary>
    /// List of item recommendation unique ids to reject.
    /// The size of the list should not exceed 100.
    /// You cannot add filter criteria along with the itemRecommendationUniqueIds list &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("itemRecommendationUniqueIds")]
    public IReadOnlyList<string>? ItemRecommendationUniqueIds { get; init; }

    /// <summary>
    /// List of rejection codes. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt;
    /// <para>
    /// | Attribute | Description | Data Type |
    /// | --- | ----------- | ------- |
    /// | NOT_SELLING_THESE_ITEMS&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | As a seller, I don’t intend to sell these items on Walmart  | string |
    /// | NOT_SELLING_THESE_BRANDS&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | As a seller, I don’t intend to sell these brands on Walmart  | string |
    /// | NOT_SELLING_THESE_CATEGORIES&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US only&lt;/span&gt;&lt;/b&gt; | As a seller, I don’t intend to sell these categories on Walmart  | string |
    /// | LIMITED_TO_OTHER_MARKETPLACE&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | As a seller, I intend to sell the rejected items only on other marketplaces  | string |
    /// | ALREADY_SELLING_ON_WALMART&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | I am already selling these items on Walmart  | string |
    /// | OTHER_REASON&lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US, CA, MX&lt;/span&gt;&lt;/b&gt; | Other reason for rejecting the items. customRejectionMessage is mandatory to pass if rejectionCode is OTHER_REASON.  | string |
    /// </para>
    /// </summary>
    [JsonPropertyName("rejectionCodes")]
    public required RejectionCodes1 RejectionCodes { get; init; }

    /// <summary>
    /// Custom rejection message if the rejection code is OTHER_REASON. This is required only when the rejectionCodes has OTHER_REASON in the list. Maximum length of the message is 500. &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: US | CA | MX&lt;/span&gt;&lt;/b&gt;
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("customRejectionMessage")]
    public string? CustomRejectionMessage { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
