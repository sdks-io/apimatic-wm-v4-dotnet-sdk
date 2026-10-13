using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Report type — Walmart Partner Reporting Platform enum name. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportType>))]
public sealed record ReportType : OpenStringEnum<ReportType>
{
    private ReportType(string value) : base(value)
    {
    }

    public static readonly ReportType Item = new("ITEM");

    public static readonly ReportType ItemPerformance = new("ITEM_PERFORMANCE");

    public static readonly ReportType Buybox = new("BUYBOX");

    public static readonly ReportType ReturnOverrides = new("RETURN_OVERRIDES");

    public static readonly ReportType Promo = new("PROMO");

    public static readonly ReportType Inventory = new("INVENTORY");

    public static readonly ReportType ShippingConfiguration = new("SHIPPING_CONFIGURATION");

    public static readonly ReportType ShippingProgram = new("SHIPPING_PROGRAM");

    public static readonly ReportType Cancellation = new("CANCELLATION");

    public static readonly ReportType DeliveryDefect = new("DELIVERY_DEFECT");

    public static readonly ReportType Cpa = new("CPA");

    public static readonly ReportType PricingInsights = new("PRICING_INSIGHTS");

    public static readonly ReportType PricingInsightsMx = new("PRICING_INSIGHTS_MX");

    public static readonly ReportType PricingInsightsCa = new("PRICING_INSIGHTS_CA");

    public static readonly ReportType WalmartFundedIncentives = new("WALMART_FUNDED_INCENTIVES");

    public static readonly ReportType IncentivesEnrollment = new("INCENTIVES_ENROLLMENT");

    public static readonly ReportType Incentives = new("INCENTIVES");

    public static readonly ReportType WalmartFundedIncentivesCa = new("WALMART_FUNDED_INCENTIVES_CA");

    public static readonly ReportType IncentivesEnrollmentCa = new("INCENTIVES_ENROLLMENT_CA");

    public static readonly ReportType IncentivesCa = new("INCENTIVES_CA");

    public static readonly ReportType FitmentAcesCoverage = new("FITMENT_ACES_COVERAGE");

    public static readonly ReportType FitmentMissingAttr = new("FITMENT_MISSING_ATTR");

    public static readonly ReportType Order = new("ORDER");

    public static readonly ReportType Otd = new("OTD");

    public static readonly ReportType B2BItem = new("B2B_ITEM");

    public static readonly ReportType OrderMx = new("ORDER_MX");

    public static readonly ReportType InventoryDsv = new("INVENTORY_DSV");

    public static readonly ReportType OrderIntl = new("ORDER_INTL");

    public static readonly ReportType ItemCa = new("ITEM_CA");

    public static readonly ReportType InventoryCa = new("INVENTORY_CA");

    public static readonly ReportType InventoryPreorder = new("INVENTORY_PREORDER");

    public static readonly ReportType ItemMx = new("ITEM_MX");

    public static readonly ReportType InventoryMx = new("INVENTORY_MX");

    public static readonly ReportType SponDealOrderMx = new("SPON_DEAL_ORDER_MX");

    public static readonly ReportType AssortmentRecommendations = new("ASSORTMENT_RECOMMENDATIONS");

    public static readonly ReportType AssortmentRecommendationsSc = new("ASSORTMENT_RECOMMENDATIONS_SC");

    public static readonly ReportType AssortmentExplorerSc = new("ASSORTMENT_EXPLORER_SC");

    public static readonly ReportType AssortmentShortlistingSc = new("ASSORTMENT_SHORTLISTING_SC");

    public static readonly ReportType AssortmentAcquisitionSc = new("ASSORTMENT_ACQUISITION_SC");

    public static readonly ReportType AssortmentOptimizationSc = new("ASSORTMENT_OPTIMIZATION_SC");

    public static readonly ReportType ProductContentData = new("PRODUCT_CONTENT_DATA");

    public static readonly ReportType ItemConfigurationData = new("ITEM_CONFIGURATION_DATA");

    public static readonly ReportType Discount = new("DISCOUNT");

    public static readonly ReportType DiscountCa = new("DISCOUNT_CA");

    public static readonly ReportType DiscountMx = new("DISCOUNT_MX");

    public static readonly ReportType Lagtime = new("LAGTIME");

    public static readonly ReportType LagtimeCa = new("LAGTIME_CA");

    public static readonly ReportType LagtimeMx = new("LAGTIME_MX");

    public static readonly ReportType LagtimeCl = new("LAGTIME_CL");

    public static readonly ReportType VirtualPack = new("VIRTUAL_PACK");

    public static readonly ReportType ItemSales = new("ITEM_SALES");

    public static readonly ReportType DsvOrders = new("DSV_ORDERS");

    public static readonly ReportType SearchInsightsPerfReport = new("SEARCH_INSIGHTS_PERF_REPORT");

    public static readonly ReportType ItemCl = new("ITEM_CL");

    public static readonly ReportType InventoryCl = new("INVENTORY_CL");

    public static readonly ReportType PaidNinety = new("PAID_NINETY");

    public static readonly ReportType ItemGroups = new("ITEM_GROUPS");

    public static readonly ReportType DraftItemGroups = new("DRAFT_ITEM_GROUPS");

    public static readonly ReportType VendorManagedPricing = new("VENDOR_MANAGED_PRICING");

    public static readonly ReportType Invoices = new("INVOICES");

    public static readonly ReportType SwwSellerReconciliation = new("SWW_SELLER_RECONCILIATION");

    public static readonly ReportType SchedulingDeliveryAndServices = new("SCHEDULING_DELIVERY_AND_SERVICES");

    public static readonly ReportType SearchInsightsSqrReport = new("SEARCH_INSIGHTS_SQR_REPORT");

    public static readonly ReportType WalmartFundedIncentivesMx = new("WALMART_FUNDED_INCENTIVES_MX");

    public static readonly ReportType IncentivesEnrollmentMx = new("INCENTIVES_ENROLLMENT_MX");

    public static readonly ReportType IncentivesMx = new("INCENTIVES_MX");

    public static readonly ReportType ApiTrafficReport = new("API_TRAFFIC_REPORT");

    public static readonly ReportType SwwEodScanForms = new("SWW_EOD_SCAN_FORMS");

    public static readonly ReportType SwwBulkPrintLabels = new("SWW_BULK_PRINT_LABELS");

    public static readonly ReportType DeleteSku = new("DELETE_SKU");

    public static readonly ReportType Promogroup = new("PROMOGROUP");

    public static readonly ReportType InventoryRecommendations = new("INVENTORY_RECOMMENDATIONS");

    public static readonly ReportType InventoryRecon = new("INVENTORY_RECON");

    public static readonly ReportType Settlement = new("SETTLEMENT");

    public static readonly ReportType WalmartFundedEs = new("WALMART_FUNDED_ES");

    public static readonly ReportType SemPerformance = new("SEM_PERFORMANCE");

    public static readonly ReportType SemSearchTerms = new("SEM_SEARCH_TERMS");

    public static readonly ReportType WfsOrders = new("WFS_ORDERS");

    public static readonly ReportType WfsInventoryLog = new("WFS_INVENTORY_LOG");

    public static readonly ReportType WfsCustomerReturns = new("WFS_CUSTOMER_RETURNS");

    public static readonly ReportType CustomItemInventory = new("CUSTOM_ITEM_INVENTORY");

    public static readonly ReportType ListingQuality = new("LISTING_QUALITY");

    public TResult Match<TResult>(Func<TResult> onItem,
        Func<TResult> onItemPerformance,
        Func<TResult> onBuybox,
        Func<TResult> onReturnOverrides,
        Func<TResult> onPromo,
        Func<TResult> onInventory,
        Func<TResult> onShippingConfiguration,
        Func<TResult> onShippingProgram,
        Func<TResult> onCancellation,
        Func<TResult> onDeliveryDefect,
        Func<TResult> onCpa,
        Func<TResult> onPricingInsights,
        Func<TResult> onPricingInsightsMx,
        Func<TResult> onPricingInsightsCa,
        Func<TResult> onWalmartFundedIncentives,
        Func<TResult> onIncentivesEnrollment,
        Func<TResult> onIncentives,
        Func<TResult> onWalmartFundedIncentivesCa,
        Func<TResult> onIncentivesEnrollmentCa,
        Func<TResult> onIncentivesCa,
        Func<TResult> onFitmentAcesCoverage,
        Func<TResult> onFitmentMissingAttr,
        Func<TResult> onOrder,
        Func<TResult> onOtd,
        Func<TResult> onB2BItem,
        Func<TResult> onOrderMx,
        Func<TResult> onInventoryDsv,
        Func<TResult> onOrderIntl,
        Func<TResult> onItemCa,
        Func<TResult> onInventoryCa,
        Func<TResult> onInventoryPreorder,
        Func<TResult> onItemMx,
        Func<TResult> onInventoryMx,
        Func<TResult> onSponDealOrderMx,
        Func<TResult> onAssortmentRecommendations,
        Func<TResult> onAssortmentRecommendationsSc,
        Func<TResult> onAssortmentExplorerSc,
        Func<TResult> onAssortmentShortlistingSc,
        Func<TResult> onAssortmentAcquisitionSc,
        Func<TResult> onAssortmentOptimizationSc,
        Func<TResult> onProductContentData,
        Func<TResult> onItemConfigurationData,
        Func<TResult> onDiscount,
        Func<TResult> onDiscountCa,
        Func<TResult> onDiscountMx,
        Func<TResult> onLagtime,
        Func<TResult> onLagtimeCa,
        Func<TResult> onLagtimeMx,
        Func<TResult> onLagtimeCl,
        Func<TResult> onVirtualPack,
        Func<TResult> onItemSales,
        Func<TResult> onDsvOrders,
        Func<TResult> onSearchInsightsPerfReport,
        Func<TResult> onItemCl,
        Func<TResult> onInventoryCl,
        Func<TResult> onPaidNinety,
        Func<TResult> onItemGroups,
        Func<TResult> onDraftItemGroups,
        Func<TResult> onVendorManagedPricing,
        Func<TResult> onInvoices,
        Func<TResult> onSwwSellerReconciliation,
        Func<TResult> onSchedulingDeliveryAndServices,
        Func<TResult> onSearchInsightsSqrReport,
        Func<TResult> onWalmartFundedIncentivesMx,
        Func<TResult> onIncentivesEnrollmentMx,
        Func<TResult> onIncentivesMx,
        Func<TResult> onApiTrafficReport,
        Func<TResult> onSwwEodScanForms,
        Func<TResult> onSwwBulkPrintLabels,
        Func<TResult> onDeleteSku,
        Func<TResult> onPromogroup,
        Func<TResult> onInventoryRecommendations,
        Func<TResult> onInventoryRecon,
        Func<TResult> onSettlement,
        Func<TResult> onWalmartFundedEs,
        Func<TResult> onSemPerformance,
        Func<TResult> onSemSearchTerms,
        Func<TResult> onWfsOrders,
        Func<TResult> onWfsInventoryLog,
        Func<TResult> onWfsCustomerReturns,
        Func<TResult> onCustomItemInventory,
        Func<TResult> onListingQuality,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Item => onItem(),
            _ when this == ItemPerformance => onItemPerformance(),
            _ when this == Buybox => onBuybox(),
            _ when this == ReturnOverrides => onReturnOverrides(),
            _ when this == Promo => onPromo(),
            _ when this == Inventory => onInventory(),
            _ when this == ShippingConfiguration => onShippingConfiguration(),
            _ when this == ShippingProgram => onShippingProgram(),
            _ when this == Cancellation => onCancellation(),
            _ when this == DeliveryDefect => onDeliveryDefect(),
            _ when this == Cpa => onCpa(),
            _ when this == PricingInsights => onPricingInsights(),
            _ when this == PricingInsightsMx => onPricingInsightsMx(),
            _ when this == PricingInsightsCa => onPricingInsightsCa(),
            _ when this == WalmartFundedIncentives => onWalmartFundedIncentives(),
            _ when this == IncentivesEnrollment => onIncentivesEnrollment(),
            _ when this == Incentives => onIncentives(),
            _ when this == WalmartFundedIncentivesCa => onWalmartFundedIncentivesCa(),
            _ when this == IncentivesEnrollmentCa => onIncentivesEnrollmentCa(),
            _ when this == IncentivesCa => onIncentivesCa(),
            _ when this == FitmentAcesCoverage => onFitmentAcesCoverage(),
            _ when this == FitmentMissingAttr => onFitmentMissingAttr(),
            _ when this == Order => onOrder(),
            _ when this == Otd => onOtd(),
            _ when this == B2BItem => onB2BItem(),
            _ when this == OrderMx => onOrderMx(),
            _ when this == InventoryDsv => onInventoryDsv(),
            _ when this == OrderIntl => onOrderIntl(),
            _ when this == ItemCa => onItemCa(),
            _ when this == InventoryCa => onInventoryCa(),
            _ when this == InventoryPreorder => onInventoryPreorder(),
            _ when this == ItemMx => onItemMx(),
            _ when this == InventoryMx => onInventoryMx(),
            _ when this == SponDealOrderMx => onSponDealOrderMx(),
            _ when this == AssortmentRecommendations => onAssortmentRecommendations(),
            _ when this == AssortmentRecommendationsSc => onAssortmentRecommendationsSc(),
            _ when this == AssortmentExplorerSc => onAssortmentExplorerSc(),
            _ when this == AssortmentShortlistingSc => onAssortmentShortlistingSc(),
            _ when this == AssortmentAcquisitionSc => onAssortmentAcquisitionSc(),
            _ when this == AssortmentOptimizationSc => onAssortmentOptimizationSc(),
            _ when this == ProductContentData => onProductContentData(),
            _ when this == ItemConfigurationData => onItemConfigurationData(),
            _ when this == Discount => onDiscount(),
            _ when this == DiscountCa => onDiscountCa(),
            _ when this == DiscountMx => onDiscountMx(),
            _ when this == Lagtime => onLagtime(),
            _ when this == LagtimeCa => onLagtimeCa(),
            _ when this == LagtimeMx => onLagtimeMx(),
            _ when this == LagtimeCl => onLagtimeCl(),
            _ when this == VirtualPack => onVirtualPack(),
            _ when this == ItemSales => onItemSales(),
            _ when this == DsvOrders => onDsvOrders(),
            _ when this == SearchInsightsPerfReport => onSearchInsightsPerfReport(),
            _ when this == ItemCl => onItemCl(),
            _ when this == InventoryCl => onInventoryCl(),
            _ when this == PaidNinety => onPaidNinety(),
            _ when this == ItemGroups => onItemGroups(),
            _ when this == DraftItemGroups => onDraftItemGroups(),
            _ when this == VendorManagedPricing => onVendorManagedPricing(),
            _ when this == Invoices => onInvoices(),
            _ when this == SwwSellerReconciliation => onSwwSellerReconciliation(),
            _ when this == SchedulingDeliveryAndServices => onSchedulingDeliveryAndServices(),
            _ when this == SearchInsightsSqrReport => onSearchInsightsSqrReport(),
            _ when this == WalmartFundedIncentivesMx => onWalmartFundedIncentivesMx(),
            _ when this == IncentivesEnrollmentMx => onIncentivesEnrollmentMx(),
            _ when this == IncentivesMx => onIncentivesMx(),
            _ when this == ApiTrafficReport => onApiTrafficReport(),
            _ when this == SwwEodScanForms => onSwwEodScanForms(),
            _ when this == SwwBulkPrintLabels => onSwwBulkPrintLabels(),
            _ when this == DeleteSku => onDeleteSku(),
            _ when this == Promogroup => onPromogroup(),
            _ when this == InventoryRecommendations => onInventoryRecommendations(),
            _ when this == InventoryRecon => onInventoryRecon(),
            _ when this == Settlement => onSettlement(),
            _ when this == WalmartFundedEs => onWalmartFundedEs(),
            _ when this == SemPerformance => onSemPerformance(),
            _ when this == SemSearchTerms => onSemSearchTerms(),
            _ when this == WfsOrders => onWfsOrders(),
            _ when this == WfsInventoryLog => onWfsInventoryLog(),
            _ when this == WfsCustomerReturns => onWfsCustomerReturns(),
            _ when this == CustomItemInventory => onCustomItemInventory(),
            _ when this == ListingQuality => onListingQuality(),
            _ => otherwise(Value)
        };

    public void Match(Action onItem,
        Action onItemPerformance,
        Action onBuybox,
        Action onReturnOverrides,
        Action onPromo,
        Action onInventory,
        Action onShippingConfiguration,
        Action onShippingProgram,
        Action onCancellation,
        Action onDeliveryDefect,
        Action onCpa,
        Action onPricingInsights,
        Action onPricingInsightsMx,
        Action onPricingInsightsCa,
        Action onWalmartFundedIncentives,
        Action onIncentivesEnrollment,
        Action onIncentives,
        Action onWalmartFundedIncentivesCa,
        Action onIncentivesEnrollmentCa,
        Action onIncentivesCa,
        Action onFitmentAcesCoverage,
        Action onFitmentMissingAttr,
        Action onOrder,
        Action onOtd,
        Action onB2BItem,
        Action onOrderMx,
        Action onInventoryDsv,
        Action onOrderIntl,
        Action onItemCa,
        Action onInventoryCa,
        Action onInventoryPreorder,
        Action onItemMx,
        Action onInventoryMx,
        Action onSponDealOrderMx,
        Action onAssortmentRecommendations,
        Action onAssortmentRecommendationsSc,
        Action onAssortmentExplorerSc,
        Action onAssortmentShortlistingSc,
        Action onAssortmentAcquisitionSc,
        Action onAssortmentOptimizationSc,
        Action onProductContentData,
        Action onItemConfigurationData,
        Action onDiscount,
        Action onDiscountCa,
        Action onDiscountMx,
        Action onLagtime,
        Action onLagtimeCa,
        Action onLagtimeMx,
        Action onLagtimeCl,
        Action onVirtualPack,
        Action onItemSales,
        Action onDsvOrders,
        Action onSearchInsightsPerfReport,
        Action onItemCl,
        Action onInventoryCl,
        Action onPaidNinety,
        Action onItemGroups,
        Action onDraftItemGroups,
        Action onVendorManagedPricing,
        Action onInvoices,
        Action onSwwSellerReconciliation,
        Action onSchedulingDeliveryAndServices,
        Action onSearchInsightsSqrReport,
        Action onWalmartFundedIncentivesMx,
        Action onIncentivesEnrollmentMx,
        Action onIncentivesMx,
        Action onApiTrafficReport,
        Action onSwwEodScanForms,
        Action onSwwBulkPrintLabels,
        Action onDeleteSku,
        Action onPromogroup,
        Action onInventoryRecommendations,
        Action onInventoryRecon,
        Action onSettlement,
        Action onWalmartFundedEs,
        Action onSemPerformance,
        Action onSemSearchTerms,
        Action onWfsOrders,
        Action onWfsInventoryLog,
        Action onWfsCustomerReturns,
        Action onCustomItemInventory,
        Action onListingQuality,
        Action<string> otherwise)
    {
        if (this == Item) onItem();
        else if (this == ItemPerformance) onItemPerformance();
        else if (this == Buybox) onBuybox();
        else if (this == ReturnOverrides) onReturnOverrides();
        else if (this == Promo) onPromo();
        else if (this == Inventory) onInventory();
        else if (this == ShippingConfiguration) onShippingConfiguration();
        else if (this == ShippingProgram) onShippingProgram();
        else if (this == Cancellation) onCancellation();
        else if (this == DeliveryDefect) onDeliveryDefect();
        else if (this == Cpa) onCpa();
        else if (this == PricingInsights) onPricingInsights();
        else if (this == PricingInsightsMx) onPricingInsightsMx();
        else if (this == PricingInsightsCa) onPricingInsightsCa();
        else if (this == WalmartFundedIncentives) onWalmartFundedIncentives();
        else if (this == IncentivesEnrollment) onIncentivesEnrollment();
        else if (this == Incentives) onIncentives();
        else if (this == WalmartFundedIncentivesCa) onWalmartFundedIncentivesCa();
        else if (this == IncentivesEnrollmentCa) onIncentivesEnrollmentCa();
        else if (this == IncentivesCa) onIncentivesCa();
        else if (this == FitmentAcesCoverage) onFitmentAcesCoverage();
        else if (this == FitmentMissingAttr) onFitmentMissingAttr();
        else if (this == Order) onOrder();
        else if (this == Otd) onOtd();
        else if (this == B2BItem) onB2BItem();
        else if (this == OrderMx) onOrderMx();
        else if (this == InventoryDsv) onInventoryDsv();
        else if (this == OrderIntl) onOrderIntl();
        else if (this == ItemCa) onItemCa();
        else if (this == InventoryCa) onInventoryCa();
        else if (this == InventoryPreorder) onInventoryPreorder();
        else if (this == ItemMx) onItemMx();
        else if (this == InventoryMx) onInventoryMx();
        else if (this == SponDealOrderMx) onSponDealOrderMx();
        else if (this == AssortmentRecommendations) onAssortmentRecommendations();
        else if (this == AssortmentRecommendationsSc) onAssortmentRecommendationsSc();
        else if (this == AssortmentExplorerSc) onAssortmentExplorerSc();
        else if (this == AssortmentShortlistingSc) onAssortmentShortlistingSc();
        else if (this == AssortmentAcquisitionSc) onAssortmentAcquisitionSc();
        else if (this == AssortmentOptimizationSc) onAssortmentOptimizationSc();
        else if (this == ProductContentData) onProductContentData();
        else if (this == ItemConfigurationData) onItemConfigurationData();
        else if (this == Discount) onDiscount();
        else if (this == DiscountCa) onDiscountCa();
        else if (this == DiscountMx) onDiscountMx();
        else if (this == Lagtime) onLagtime();
        else if (this == LagtimeCa) onLagtimeCa();
        else if (this == LagtimeMx) onLagtimeMx();
        else if (this == LagtimeCl) onLagtimeCl();
        else if (this == VirtualPack) onVirtualPack();
        else if (this == ItemSales) onItemSales();
        else if (this == DsvOrders) onDsvOrders();
        else if (this == SearchInsightsPerfReport) onSearchInsightsPerfReport();
        else if (this == ItemCl) onItemCl();
        else if (this == InventoryCl) onInventoryCl();
        else if (this == PaidNinety) onPaidNinety();
        else if (this == ItemGroups) onItemGroups();
        else if (this == DraftItemGroups) onDraftItemGroups();
        else if (this == VendorManagedPricing) onVendorManagedPricing();
        else if (this == Invoices) onInvoices();
        else if (this == SwwSellerReconciliation) onSwwSellerReconciliation();
        else if (this == SchedulingDeliveryAndServices) onSchedulingDeliveryAndServices();
        else if (this == SearchInsightsSqrReport) onSearchInsightsSqrReport();
        else if (this == WalmartFundedIncentivesMx) onWalmartFundedIncentivesMx();
        else if (this == IncentivesEnrollmentMx) onIncentivesEnrollmentMx();
        else if (this == IncentivesMx) onIncentivesMx();
        else if (this == ApiTrafficReport) onApiTrafficReport();
        else if (this == SwwEodScanForms) onSwwEodScanForms();
        else if (this == SwwBulkPrintLabels) onSwwBulkPrintLabels();
        else if (this == DeleteSku) onDeleteSku();
        else if (this == Promogroup) onPromogroup();
        else if (this == InventoryRecommendations) onInventoryRecommendations();
        else if (this == InventoryRecon) onInventoryRecon();
        else if (this == Settlement) onSettlement();
        else if (this == WalmartFundedEs) onWalmartFundedEs();
        else if (this == SemPerformance) onSemPerformance();
        else if (this == SemSearchTerms) onSemSearchTerms();
        else if (this == WfsOrders) onWfsOrders();
        else if (this == WfsInventoryLog) onWfsInventoryLog();
        else if (this == WfsCustomerReturns) onWfsCustomerReturns();
        else if (this == CustomItemInventory) onCustomItemInventory();
        else if (this == ListingQuality) onListingQuality();
        else otherwise(Value);
    }
}
