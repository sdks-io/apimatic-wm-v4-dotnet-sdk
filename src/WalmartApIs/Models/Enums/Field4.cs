using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Attribute | Description | Data Type
/// | --- | ----------- | -------
/// | contentDiscoverabilityPercentage | Item's content and discoverability score expressed as a percentage. | string |
/// | qualityScorePercentage | Item's overall Listing Quality score, rated as a percentage. | string |
/// | offerPercentage | Item's offer score, based on: item price, shipping price and speed, and in-stock rate.| string |
/// | ratingReviewsPercentage | Rating and reviews score, as a percentage. | string |
/// | viewTrendingItems | Indicates to return details for trending items that have non-zero page views. Acceptable values are "true" if pageView &gt; 0, or "false" if pageView &gt;= 0. | string |
/// | viewPostPurchaseItems | Show items with post-purchase quality issues. If item has post-purchase value &gt;= 1, it filters all items greater or equal based on post purchase value. | string |
/// | wfsFlag | Show WFS-eligible items. Value of this parameter can be true or false. | string |
/// | categoryName | Item's category name. | string |
/// | hasIssues | Provides a count of item with issues. | integer |
/// | productType | Product type to classify the item (e.g. Pants). | string|
/// | attributeList | List of all available filter attributes. | string |
/// | productTypes | List of all available product. | List&lt;String&gt; |
/// | brandList | List of all available brand. | List&lt;String&gt; |
/// | oos | Filter using out of stock offer based on days. Min value = 0, Max Value = 7. | integer |
/// | fastAndFreeShipping | Possible values are 1 for offers eligible for free shipping and 0 for offers not eligible for free shipping. No value shows all the offers. | integer |
/// | priceMeetBeatFlag | Possible values are -1 for no match, 0 for lose, 1 for meets and 2 for beats. No value shows all the offers. | integer |
/// | conditionList | Specifies the condition of the item. Can take values (New, New without box, New without tags, Restored Premium, Restored, Remanufactured, Open Box, Pre-Owned: Like New, Pre-Owned: Good, Pre-Owned: Fair, New with defects) | List&lt;String&gt;
/// </summary>
[JsonConverter(typeof(StringEnumConverter<Field4>))]
public sealed record Field4 : OpenStringEnum<Field4>
{
    private Field4(string value) : base(value)
    {
    }

    public static readonly Field4 ContentDiscoverabilityPercentage = new("contentDiscoverabilityPercentage");

    public static readonly Field4 QualityScorePercentage = new("qualityScorePercentage");

    public static readonly Field4 OfferPercentage = new("offerPercentage");

    public static readonly Field4 RatingReviewsPercentage = new("ratingReviewsPercentage");

    public static readonly Field4 ViewTrendingItems = new("viewTrendingItems");

    public static readonly Field4 ViewPostPurchaseItems = new("viewPostPurchaseItems");

    public static readonly Field4 WfsFlag = new("wfsFlag");

    public static readonly Field4 CategoryName = new("categoryName");

    public static readonly Field4 HasIssues = new("hasIssues");

    public static readonly Field4 ProductType = new("productType");

    public static readonly Field4 AttributeList = new("attributeList");

    public static readonly Field4 ProductTypes = new("productTypes");

    public static readonly Field4 BrandList = new("brandList");

    public static readonly Field4 Oos = new("oos");

    public static readonly Field4 FastAndFreeShipping = new("fastAndFreeShipping");

    public static readonly Field4 PriceMeetBeatFlag = new("priceMeetBeatFlag");

    public static readonly Field4 ConditionList = new("conditionList");

    public TResult Match<TResult>(Func<TResult> onContentDiscoverabilityPercentage,
        Func<TResult> onQualityScorePercentage,
        Func<TResult> onOfferPercentage,
        Func<TResult> onRatingReviewsPercentage,
        Func<TResult> onViewTrendingItems,
        Func<TResult> onViewPostPurchaseItems,
        Func<TResult> onWfsFlag,
        Func<TResult> onCategoryName,
        Func<TResult> onHasIssues,
        Func<TResult> onProductType,
        Func<TResult> onAttributeList,
        Func<TResult> onProductTypes,
        Func<TResult> onBrandList,
        Func<TResult> onOos,
        Func<TResult> onFastAndFreeShipping,
        Func<TResult> onPriceMeetBeatFlag,
        Func<TResult> onConditionList,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == ContentDiscoverabilityPercentage => onContentDiscoverabilityPercentage(),
            _ when this == QualityScorePercentage => onQualityScorePercentage(),
            _ when this == OfferPercentage => onOfferPercentage(),
            _ when this == RatingReviewsPercentage => onRatingReviewsPercentage(),
            _ when this == ViewTrendingItems => onViewTrendingItems(),
            _ when this == ViewPostPurchaseItems => onViewPostPurchaseItems(),
            _ when this == WfsFlag => onWfsFlag(),
            _ when this == CategoryName => onCategoryName(),
            _ when this == HasIssues => onHasIssues(),
            _ when this == ProductType => onProductType(),
            _ when this == AttributeList => onAttributeList(),
            _ when this == ProductTypes => onProductTypes(),
            _ when this == BrandList => onBrandList(),
            _ when this == Oos => onOos(),
            _ when this == FastAndFreeShipping => onFastAndFreeShipping(),
            _ when this == PriceMeetBeatFlag => onPriceMeetBeatFlag(),
            _ when this == ConditionList => onConditionList(),
            _ => otherwise(Value)
        };

    public void Match(Action onContentDiscoverabilityPercentage,
        Action onQualityScorePercentage,
        Action onOfferPercentage,
        Action onRatingReviewsPercentage,
        Action onViewTrendingItems,
        Action onViewPostPurchaseItems,
        Action onWfsFlag,
        Action onCategoryName,
        Action onHasIssues,
        Action onProductType,
        Action onAttributeList,
        Action onProductTypes,
        Action onBrandList,
        Action onOos,
        Action onFastAndFreeShipping,
        Action onPriceMeetBeatFlag,
        Action onConditionList,
        Action<string> otherwise)
    {
        if (this == ContentDiscoverabilityPercentage) onContentDiscoverabilityPercentage();
        else if (this == QualityScorePercentage) onQualityScorePercentage();
        else if (this == OfferPercentage) onOfferPercentage();
        else if (this == RatingReviewsPercentage) onRatingReviewsPercentage();
        else if (this == ViewTrendingItems) onViewTrendingItems();
        else if (this == ViewPostPurchaseItems) onViewPostPurchaseItems();
        else if (this == WfsFlag) onWfsFlag();
        else if (this == CategoryName) onCategoryName();
        else if (this == HasIssues) onHasIssues();
        else if (this == ProductType) onProductType();
        else if (this == AttributeList) onAttributeList();
        else if (this == ProductTypes) onProductTypes();
        else if (this == BrandList) onBrandList();
        else if (this == Oos) onOos();
        else if (this == FastAndFreeShipping) onFastAndFreeShipping();
        else if (this == PriceMeetBeatFlag) onPriceMeetBeatFlag();
        else if (this == ConditionList) onConditionList();
        else otherwise(Value);
    }
}
