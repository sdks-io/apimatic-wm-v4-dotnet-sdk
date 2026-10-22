using System.Text.Json.Serialization;
using WalmartApIs.Core.Models;

namespace WalmartApIs.Models;

public record ItemPriceType
{
    [JsonPropertyName("itemIdentifier")]
    public required ItemIdentifierType ItemIdentifier { get; init; }

    [JsonPropertyName("pricingList")]
    public required PricingListType PricingList { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("maxSalesRetailPrice")]
    public MoneyType? MaxSalesRetailPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("minAdvtPrice")]
    public MoneyType? MinAdvtPrice { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("rebate")]
    public Rebate? Rebate { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("additionalAttributes")]
    public AdditionalAttributes1? AdditionalAttributes { get; init; }

    [JsonExtensionData]
    public AdditionalProperties AdditionalProperties { get; init; } = [];
}
