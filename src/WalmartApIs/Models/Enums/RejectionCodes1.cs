using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

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
[JsonConverter(typeof(StringEnumConverter<RejectionCodes1>))]
public sealed record RejectionCodes1 : OpenStringEnum<RejectionCodes1>
{
    private RejectionCodes1(string value) : base(value)
    {
    }

    public static readonly RejectionCodes1 NotSellingTheseItems = new("NOT_SELLING_THESE_ITEMS");

    public static readonly RejectionCodes1 NotSellingTheseBrands = new("NOT_SELLING_THESE_BRANDS");

    public static readonly RejectionCodes1 NotSellingTheseCategories = new("NOT_SELLING_THESE_CATEGORIES");

    public static readonly RejectionCodes1 LimitedToOtherMarketplace = new("LIMITED_TO_OTHER_MARKETPLACE");

    public static readonly RejectionCodes1 AlreadySellingOnWalmart = new("ALREADY_SELLING_ON_WALMART");

    public static readonly RejectionCodes1 OtherReason = new("OTHER_REASON");

    public TResult Match<TResult>(Func<TResult> onNotSellingTheseItems,
        Func<TResult> onNotSellingTheseBrands,
        Func<TResult> onNotSellingTheseCategories,
        Func<TResult> onLimitedToOtherMarketplace,
        Func<TResult> onAlreadySellingOnWalmart,
        Func<TResult> onOtherReason,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == NotSellingTheseItems => onNotSellingTheseItems(),
            _ when this == NotSellingTheseBrands => onNotSellingTheseBrands(),
            _ when this == NotSellingTheseCategories => onNotSellingTheseCategories(),
            _ when this == LimitedToOtherMarketplace => onLimitedToOtherMarketplace(),
            _ when this == AlreadySellingOnWalmart => onAlreadySellingOnWalmart(),
            _ when this == OtherReason => onOtherReason(),
            _ => otherwise(Value)
        };

    public void Match(Action onNotSellingTheseItems,
        Action onNotSellingTheseBrands,
        Action onNotSellingTheseCategories,
        Action onLimitedToOtherMarketplace,
        Action onAlreadySellingOnWalmart,
        Action onOtherReason,
        Action<string> otherwise)
    {
        if (this == NotSellingTheseItems) onNotSellingTheseItems();
        else if (this == NotSellingTheseBrands) onNotSellingTheseBrands();
        else if (this == NotSellingTheseCategories) onNotSellingTheseCategories();
        else if (this == LimitedToOtherMarketplace) onLimitedToOtherMarketplace();
        else if (this == AlreadySellingOnWalmart) onAlreadySellingOnWalmart();
        else if (this == OtherReason) onOtherReason();
        else otherwise(Value);
    }
}
