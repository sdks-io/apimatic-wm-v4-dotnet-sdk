using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Report type — Walmart Partner Reporting Platform enum name. Runtime availability is CCM-controlled; consult PRP docs for current PROD-enabled types.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportType>))]
public sealed record ReportType : StringEnum<ReportType>
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

    public static ReportType FromValue(string value) => FromValueCore(value);
}
