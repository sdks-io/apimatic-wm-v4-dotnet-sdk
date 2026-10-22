using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Lookup key into the issue metadata returned by the <c>GET /item-issues/issue-types</c> endpoint. Maps to one of the supported issue type enum values.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<IssueType>))]
public sealed record IssueType : OpenStringEnum<IssueType>
{
    private IssueType(string value) : base(value)
    {
    }

    public static readonly IssueType BuyboxNotWinner = new("BUYBOX_NOT_WINNER");

    public static readonly IssueType SingleColorImage = new("SINGLE_COLOR_IMAGE");

    public static readonly IssueType ShippingPriceTooHigh = new("SHIPPING_PRICE_TOO_HIGH");

    public static readonly IssueType ShippingNotOffered = new("SHIPPING_NOT_OFFERED");

    public static readonly IssueType PromotionalOverlayImage = new("PROMOTIONAL_OVERLAY_IMAGE");

    public static readonly IssueType MissingInvalidTitle = new("MISSING_INVALID_TITLE");

    public static readonly IssueType MissingInvalidPrice = new("MISSING_INVALID_PRICE");

    public static readonly IssueType MissingInvalidDescription = new("MISSING_INVALID_DESCRIPTION");

    public static readonly IssueType InvalidMpn = new("INVALID_MPN");

    public static readonly IssueType InvalidImage = new("INVALID_IMAGE");

    public static readonly IssueType InvalidGtin = new("INVALID_GTIN");

    public static readonly IssueType InvalidCharactersTitle = new("INVALID_CHARACTERS_TITLE");

    public static readonly IssueType InvalidCharactersTitleUtf8 = new("INVALID_CHARACTERS_TITLE_UTF8");

    public static readonly IssueType InvalidBrand = new("INVALID_BRAND");

    public static readonly IssueType ImageTooSmall = new("IMAGE_TOO_SMALL");

    public static readonly IssueType ImageTooBig = new("IMAGE_TOO_BIG");

    public static readonly IssueType GenericImage = new("GENERIC_IMAGE");

    public static readonly IssueType ExtraneousTextTitle = new("EXTRANEOUS_TEXT_TITLE");

    public static readonly IssueType AdditionalImageTooSmall = new("ADDITIONAL_IMAGE_TOO_SMALL");

    public static readonly IssueType AdditionalImageTooBig = new("ADDITIONAL_IMAGE_TOO_BIG");

    public static readonly IssueType ItemNotAvailable = new("ITEM_NOT_AVAILABLE");

    public static readonly IssueType PolicyViolation = new("POLICY_VIOLATION");

    public static readonly IssueType PolicyViolationHazardousMaterials = new("POLICY_VIOLATION_HAZARDOUS_MATERIALS");

    public static readonly IssueType PolicyViolationUnapprovedSupplement = new(
        "POLICY_VIOLATION_UNAPPROVED_SUPPLEMENT");

    public static readonly IssueType PolicyViolationUnapprovedPharmaceuticals = new(
        "POLICY_VIOLATION_UNAPPROVED_PHARMACEUTICALS");

    public static readonly IssueType PolicyViolationHealthcarePrescription = new(
        "POLICY_VIOLATION_HEALTHCARE_PRESCRIPTION");

    public static readonly IssueType PolicyViolationHealthcareMisleading = new(
        "POLICY_VIOLATION_HEALTHCARE_MISLEADING");

    public static readonly IssueType PolicyViolationTobacco = new("POLICY_VIOLATION_TOBACCO");

    public static readonly IssueType PolicyViolationSodiumNitrite = new("POLICY_VIOLATION_SODIUM_NITRITE");

    public static readonly IssueType PolicyViolationServices = new("POLICY_VIOLATION_SERVICES");

    public static readonly IssueType PolicyViolationSensitiveIssues = new("POLICY_VIOLATION_SENSITIVE_ISSUES");

    public static readonly IssueType PolicyViolationRecalled = new("POLICY_VIOLATION_RECALLED");

    public static readonly IssueType PolicyViolationOffensiveContent = new("POLICY_VIOLATION_OFFENSIVE_CONTENT");

    public static readonly IssueType PolicyViolationLocal = new("POLICY_VIOLATION_LOCAL");

    public static readonly IssueType PolicyViolationLiveAnimals = new("POLICY_VIOLATION_LIVE_ANIMALS");

    public static readonly IssueType PolicyViolationImmovableProperty = new("POLICY_VIOLATION_IMMOVABLE_PROPERTY");

    public static readonly IssueType PolicyViolationHacking = new("POLICY_VIOLATION_HACKING");

    public static readonly IssueType PolicyViolationGambling = new("POLICY_VIOLATION_GAMBLING");

    public static readonly IssueType PolicyViolationEndangeredSpecies = new("POLICY_VIOLATION_ENDANGERED_SPECIES");

    public static readonly IssueType PolicyViolationIllegalDrugs = new("POLICY_VIOLATION_ILLEGAL_DRUGS");

    public static readonly IssueType PolicyViolationOtherWeapons = new("POLICY_VIOLATION_OTHER_WEAPONS");

    public static readonly IssueType PolicyViolationGunsAndParts = new("POLICY_VIOLATION_GUNS_AND_PARTS");

    public static readonly IssueType PolicyViolationExplosives = new("POLICY_VIOLATION_EXPLOSIVES");

    public static readonly IssueType PolicyViolationDangerousKnives = new("POLICY_VIOLATION_DANGEROUS_KNIVES");

    public static readonly IssueType PolicyViolationWholesaleCurrency = new("POLICY_VIOLATION_WHOLESALE_CURRENCY");

    public static readonly IssueType PolicyViolationCounterfeit = new("POLICY_VIOLATION_COUNTERFEIT");

    public static readonly IssueType PolicyViolationAdultContent = new("POLICY_VIOLATION_ADULT_CONTENT");

    public static readonly IssueType ItemUnpublished = new("ITEM_UNPUBLISHED");

    public static readonly IssueType DuplicateOffer = new("DUPLICATE_OFFER");

    public static readonly IssueType InvalidAdditionalImage = new("INVALID_ADDITIONAL_IMAGE");

    public static readonly IssueType DescriptionTooShort = new("DESCRIPTION_TOO_SHORT");

    public static readonly IssueType DescriptionTooLong = new("DESCRIPTION_TOO_LONG");

    public static readonly IssueType LowImageQuality = new("LOW_IMAGE_QUALITY");

    public static readonly IssueType ExcessiveCapitalizationTitle = new("EXCESSIVE_CAPITALIZATION_TITLE");

    public static readonly IssueType AdultContent = new("ADULT_CONTENT");

    public static readonly IssueType TitleTooLong = new("TITLE_TOO_LONG");

    public static readonly IssueType ExtraneousTextTitleWarning = new("EXTRANEOUS_TEXT_TITLE_WARNING");

    public static readonly IssueType ItemLimited = new("ITEM_LIMITED");

    public static readonly IssueType ItemOutOfStock = new("ITEM_OUT_OF_STOCK");

    public static readonly IssueType ItemPriceTooHigh = new("ITEM_PRICE_TOO_HIGH");

    public static readonly IssueType LowOfferListingQuality = new("LOW_OFFER_LISTING_QUALITY");

    public TResult Match<TResult>(Func<TResult> onBuyboxNotWinner,
        Func<TResult> onSingleColorImage,
        Func<TResult> onShippingPriceTooHigh,
        Func<TResult> onShippingNotOffered,
        Func<TResult> onPromotionalOverlayImage,
        Func<TResult> onMissingInvalidTitle,
        Func<TResult> onMissingInvalidPrice,
        Func<TResult> onMissingInvalidDescription,
        Func<TResult> onInvalidMpn,
        Func<TResult> onInvalidImage,
        Func<TResult> onInvalidGtin,
        Func<TResult> onInvalidCharactersTitle,
        Func<TResult> onInvalidCharactersTitleUtf8,
        Func<TResult> onInvalidBrand,
        Func<TResult> onImageTooSmall,
        Func<TResult> onImageTooBig,
        Func<TResult> onGenericImage,
        Func<TResult> onExtraneousTextTitle,
        Func<TResult> onAdditionalImageTooSmall,
        Func<TResult> onAdditionalImageTooBig,
        Func<TResult> onItemNotAvailable,
        Func<TResult> onPolicyViolation,
        Func<TResult> onPolicyViolationHazardousMaterials,
        Func<TResult> onPolicyViolationUnapprovedSupplement,
        Func<TResult> onPolicyViolationUnapprovedPharmaceuticals,
        Func<TResult> onPolicyViolationHealthcarePrescription,
        Func<TResult> onPolicyViolationHealthcareMisleading,
        Func<TResult> onPolicyViolationTobacco,
        Func<TResult> onPolicyViolationSodiumNitrite,
        Func<TResult> onPolicyViolationServices,
        Func<TResult> onPolicyViolationSensitiveIssues,
        Func<TResult> onPolicyViolationRecalled,
        Func<TResult> onPolicyViolationOffensiveContent,
        Func<TResult> onPolicyViolationLocal,
        Func<TResult> onPolicyViolationLiveAnimals,
        Func<TResult> onPolicyViolationImmovableProperty,
        Func<TResult> onPolicyViolationHacking,
        Func<TResult> onPolicyViolationGambling,
        Func<TResult> onPolicyViolationEndangeredSpecies,
        Func<TResult> onPolicyViolationIllegalDrugs,
        Func<TResult> onPolicyViolationOtherWeapons,
        Func<TResult> onPolicyViolationGunsAndParts,
        Func<TResult> onPolicyViolationExplosives,
        Func<TResult> onPolicyViolationDangerousKnives,
        Func<TResult> onPolicyViolationWholesaleCurrency,
        Func<TResult> onPolicyViolationCounterfeit,
        Func<TResult> onPolicyViolationAdultContent,
        Func<TResult> onItemUnpublished,
        Func<TResult> onDuplicateOffer,
        Func<TResult> onInvalidAdditionalImage,
        Func<TResult> onDescriptionTooShort,
        Func<TResult> onDescriptionTooLong,
        Func<TResult> onLowImageQuality,
        Func<TResult> onExcessiveCapitalizationTitle,
        Func<TResult> onAdultContent,
        Func<TResult> onTitleTooLong,
        Func<TResult> onExtraneousTextTitleWarning,
        Func<TResult> onItemLimited,
        Func<TResult> onItemOutOfStock,
        Func<TResult> onItemPriceTooHigh,
        Func<TResult> onLowOfferListingQuality,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == BuyboxNotWinner => onBuyboxNotWinner(),
            _ when this == SingleColorImage => onSingleColorImage(),
            _ when this == ShippingPriceTooHigh => onShippingPriceTooHigh(),
            _ when this == ShippingNotOffered => onShippingNotOffered(),
            _ when this == PromotionalOverlayImage => onPromotionalOverlayImage(),
            _ when this == MissingInvalidTitle => onMissingInvalidTitle(),
            _ when this == MissingInvalidPrice => onMissingInvalidPrice(),
            _ when this == MissingInvalidDescription => onMissingInvalidDescription(),
            _ when this == InvalidMpn => onInvalidMpn(),
            _ when this == InvalidImage => onInvalidImage(),
            _ when this == InvalidGtin => onInvalidGtin(),
            _ when this == InvalidCharactersTitle => onInvalidCharactersTitle(),
            _ when this == InvalidCharactersTitleUtf8 => onInvalidCharactersTitleUtf8(),
            _ when this == InvalidBrand => onInvalidBrand(),
            _ when this == ImageTooSmall => onImageTooSmall(),
            _ when this == ImageTooBig => onImageTooBig(),
            _ when this == GenericImage => onGenericImage(),
            _ when this == ExtraneousTextTitle => onExtraneousTextTitle(),
            _ when this == AdditionalImageTooSmall => onAdditionalImageTooSmall(),
            _ when this == AdditionalImageTooBig => onAdditionalImageTooBig(),
            _ when this == ItemNotAvailable => onItemNotAvailable(),
            _ when this == PolicyViolation => onPolicyViolation(),
            _ when this == PolicyViolationHazardousMaterials => onPolicyViolationHazardousMaterials(),
            _ when this == PolicyViolationUnapprovedSupplement => onPolicyViolationUnapprovedSupplement(),
            _ when this == PolicyViolationUnapprovedPharmaceuticals => onPolicyViolationUnapprovedPharmaceuticals(),
            _ when this == PolicyViolationHealthcarePrescription => onPolicyViolationHealthcarePrescription(),
            _ when this == PolicyViolationHealthcareMisleading => onPolicyViolationHealthcareMisleading(),
            _ when this == PolicyViolationTobacco => onPolicyViolationTobacco(),
            _ when this == PolicyViolationSodiumNitrite => onPolicyViolationSodiumNitrite(),
            _ when this == PolicyViolationServices => onPolicyViolationServices(),
            _ when this == PolicyViolationSensitiveIssues => onPolicyViolationSensitiveIssues(),
            _ when this == PolicyViolationRecalled => onPolicyViolationRecalled(),
            _ when this == PolicyViolationOffensiveContent => onPolicyViolationOffensiveContent(),
            _ when this == PolicyViolationLocal => onPolicyViolationLocal(),
            _ when this == PolicyViolationLiveAnimals => onPolicyViolationLiveAnimals(),
            _ when this == PolicyViolationImmovableProperty => onPolicyViolationImmovableProperty(),
            _ when this == PolicyViolationHacking => onPolicyViolationHacking(),
            _ when this == PolicyViolationGambling => onPolicyViolationGambling(),
            _ when this == PolicyViolationEndangeredSpecies => onPolicyViolationEndangeredSpecies(),
            _ when this == PolicyViolationIllegalDrugs => onPolicyViolationIllegalDrugs(),
            _ when this == PolicyViolationOtherWeapons => onPolicyViolationOtherWeapons(),
            _ when this == PolicyViolationGunsAndParts => onPolicyViolationGunsAndParts(),
            _ when this == PolicyViolationExplosives => onPolicyViolationExplosives(),
            _ when this == PolicyViolationDangerousKnives => onPolicyViolationDangerousKnives(),
            _ when this == PolicyViolationWholesaleCurrency => onPolicyViolationWholesaleCurrency(),
            _ when this == PolicyViolationCounterfeit => onPolicyViolationCounterfeit(),
            _ when this == PolicyViolationAdultContent => onPolicyViolationAdultContent(),
            _ when this == ItemUnpublished => onItemUnpublished(),
            _ when this == DuplicateOffer => onDuplicateOffer(),
            _ when this == InvalidAdditionalImage => onInvalidAdditionalImage(),
            _ when this == DescriptionTooShort => onDescriptionTooShort(),
            _ when this == DescriptionTooLong => onDescriptionTooLong(),
            _ when this == LowImageQuality => onLowImageQuality(),
            _ when this == ExcessiveCapitalizationTitle => onExcessiveCapitalizationTitle(),
            _ when this == AdultContent => onAdultContent(),
            _ when this == TitleTooLong => onTitleTooLong(),
            _ when this == ExtraneousTextTitleWarning => onExtraneousTextTitleWarning(),
            _ when this == ItemLimited => onItemLimited(),
            _ when this == ItemOutOfStock => onItemOutOfStock(),
            _ when this == ItemPriceTooHigh => onItemPriceTooHigh(),
            _ when this == LowOfferListingQuality => onLowOfferListingQuality(),
            _ => otherwise(Value)
        };

    public void Match(Action onBuyboxNotWinner,
        Action onSingleColorImage,
        Action onShippingPriceTooHigh,
        Action onShippingNotOffered,
        Action onPromotionalOverlayImage,
        Action onMissingInvalidTitle,
        Action onMissingInvalidPrice,
        Action onMissingInvalidDescription,
        Action onInvalidMpn,
        Action onInvalidImage,
        Action onInvalidGtin,
        Action onInvalidCharactersTitle,
        Action onInvalidCharactersTitleUtf8,
        Action onInvalidBrand,
        Action onImageTooSmall,
        Action onImageTooBig,
        Action onGenericImage,
        Action onExtraneousTextTitle,
        Action onAdditionalImageTooSmall,
        Action onAdditionalImageTooBig,
        Action onItemNotAvailable,
        Action onPolicyViolation,
        Action onPolicyViolationHazardousMaterials,
        Action onPolicyViolationUnapprovedSupplement,
        Action onPolicyViolationUnapprovedPharmaceuticals,
        Action onPolicyViolationHealthcarePrescription,
        Action onPolicyViolationHealthcareMisleading,
        Action onPolicyViolationTobacco,
        Action onPolicyViolationSodiumNitrite,
        Action onPolicyViolationServices,
        Action onPolicyViolationSensitiveIssues,
        Action onPolicyViolationRecalled,
        Action onPolicyViolationOffensiveContent,
        Action onPolicyViolationLocal,
        Action onPolicyViolationLiveAnimals,
        Action onPolicyViolationImmovableProperty,
        Action onPolicyViolationHacking,
        Action onPolicyViolationGambling,
        Action onPolicyViolationEndangeredSpecies,
        Action onPolicyViolationIllegalDrugs,
        Action onPolicyViolationOtherWeapons,
        Action onPolicyViolationGunsAndParts,
        Action onPolicyViolationExplosives,
        Action onPolicyViolationDangerousKnives,
        Action onPolicyViolationWholesaleCurrency,
        Action onPolicyViolationCounterfeit,
        Action onPolicyViolationAdultContent,
        Action onItemUnpublished,
        Action onDuplicateOffer,
        Action onInvalidAdditionalImage,
        Action onDescriptionTooShort,
        Action onDescriptionTooLong,
        Action onLowImageQuality,
        Action onExcessiveCapitalizationTitle,
        Action onAdultContent,
        Action onTitleTooLong,
        Action onExtraneousTextTitleWarning,
        Action onItemLimited,
        Action onItemOutOfStock,
        Action onItemPriceTooHigh,
        Action onLowOfferListingQuality,
        Action<string> otherwise)
    {
        if (this == BuyboxNotWinner) onBuyboxNotWinner();
        else if (this == SingleColorImage) onSingleColorImage();
        else if (this == ShippingPriceTooHigh) onShippingPriceTooHigh();
        else if (this == ShippingNotOffered) onShippingNotOffered();
        else if (this == PromotionalOverlayImage) onPromotionalOverlayImage();
        else if (this == MissingInvalidTitle) onMissingInvalidTitle();
        else if (this == MissingInvalidPrice) onMissingInvalidPrice();
        else if (this == MissingInvalidDescription) onMissingInvalidDescription();
        else if (this == InvalidMpn) onInvalidMpn();
        else if (this == InvalidImage) onInvalidImage();
        else if (this == InvalidGtin) onInvalidGtin();
        else if (this == InvalidCharactersTitle) onInvalidCharactersTitle();
        else if (this == InvalidCharactersTitleUtf8) onInvalidCharactersTitleUtf8();
        else if (this == InvalidBrand) onInvalidBrand();
        else if (this == ImageTooSmall) onImageTooSmall();
        else if (this == ImageTooBig) onImageTooBig();
        else if (this == GenericImage) onGenericImage();
        else if (this == ExtraneousTextTitle) onExtraneousTextTitle();
        else if (this == AdditionalImageTooSmall) onAdditionalImageTooSmall();
        else if (this == AdditionalImageTooBig) onAdditionalImageTooBig();
        else if (this == ItemNotAvailable) onItemNotAvailable();
        else if (this == PolicyViolation) onPolicyViolation();
        else if (this == PolicyViolationHazardousMaterials) onPolicyViolationHazardousMaterials();
        else if (this == PolicyViolationUnapprovedSupplement) onPolicyViolationUnapprovedSupplement();
        else if (this == PolicyViolationUnapprovedPharmaceuticals) onPolicyViolationUnapprovedPharmaceuticals();
        else if (this == PolicyViolationHealthcarePrescription) onPolicyViolationHealthcarePrescription();
        else if (this == PolicyViolationHealthcareMisleading) onPolicyViolationHealthcareMisleading();
        else if (this == PolicyViolationTobacco) onPolicyViolationTobacco();
        else if (this == PolicyViolationSodiumNitrite) onPolicyViolationSodiumNitrite();
        else if (this == PolicyViolationServices) onPolicyViolationServices();
        else if (this == PolicyViolationSensitiveIssues) onPolicyViolationSensitiveIssues();
        else if (this == PolicyViolationRecalled) onPolicyViolationRecalled();
        else if (this == PolicyViolationOffensiveContent) onPolicyViolationOffensiveContent();
        else if (this == PolicyViolationLocal) onPolicyViolationLocal();
        else if (this == PolicyViolationLiveAnimals) onPolicyViolationLiveAnimals();
        else if (this == PolicyViolationImmovableProperty) onPolicyViolationImmovableProperty();
        else if (this == PolicyViolationHacking) onPolicyViolationHacking();
        else if (this == PolicyViolationGambling) onPolicyViolationGambling();
        else if (this == PolicyViolationEndangeredSpecies) onPolicyViolationEndangeredSpecies();
        else if (this == PolicyViolationIllegalDrugs) onPolicyViolationIllegalDrugs();
        else if (this == PolicyViolationOtherWeapons) onPolicyViolationOtherWeapons();
        else if (this == PolicyViolationGunsAndParts) onPolicyViolationGunsAndParts();
        else if (this == PolicyViolationExplosives) onPolicyViolationExplosives();
        else if (this == PolicyViolationDangerousKnives) onPolicyViolationDangerousKnives();
        else if (this == PolicyViolationWholesaleCurrency) onPolicyViolationWholesaleCurrency();
        else if (this == PolicyViolationCounterfeit) onPolicyViolationCounterfeit();
        else if (this == PolicyViolationAdultContent) onPolicyViolationAdultContent();
        else if (this == ItemUnpublished) onItemUnpublished();
        else if (this == DuplicateOffer) onDuplicateOffer();
        else if (this == InvalidAdditionalImage) onInvalidAdditionalImage();
        else if (this == DescriptionTooShort) onDescriptionTooShort();
        else if (this == DescriptionTooLong) onDescriptionTooLong();
        else if (this == LowImageQuality) onLowImageQuality();
        else if (this == ExcessiveCapitalizationTitle) onExcessiveCapitalizationTitle();
        else if (this == AdultContent) onAdultContent();
        else if (this == TitleTooLong) onTitleTooLong();
        else if (this == ExtraneousTextTitleWarning) onExtraneousTextTitleWarning();
        else if (this == ItemLimited) onItemLimited();
        else if (this == ItemOutOfStock) onItemOutOfStock();
        else if (this == ItemPriceTooHigh) onItemPriceTooHigh();
        else if (this == LowOfferListingQuality) onLowOfferListingQuality();
        else otherwise(Value);
    }
}
