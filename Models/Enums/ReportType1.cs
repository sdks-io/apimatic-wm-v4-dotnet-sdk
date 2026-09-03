using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

[JsonConverter(typeof(StringEnumConverter<ReportType1>))]
public sealed record ReportType1 : StringEnum<ReportType1>
{
    private ReportType1(string value) : base(value)
    {
    }

    public static readonly ReportType1 Item = new("ITEM");

    public static readonly ReportType1 ItemPerformance = new("ITEM_PERFORMANCE");

    public static readonly ReportType1 Buybox = new("BUYBOX");

    public static readonly ReportType1 ReturnOverrides = new("RETURN_OVERRIDES");

    public static readonly ReportType1 Promo = new("PROMO");

    public static readonly ReportType1 Inventory = new("INVENTORY");

    public static readonly ReportType1 ShippingConfiguration = new("SHIPPING_CONFIGURATION");

    public static readonly ReportType1 ShippingProgram = new("SHIPPING_PROGRAM");

    public static readonly ReportType1 Cancellation = new("CANCELLATION");

    public static readonly ReportType1 DeliveryDefect = new("DELIVERY_DEFECT");

    public static readonly ReportType1 Cpa = new("CPA");

    public static readonly ReportType1 PricingInsights = new("PRICING_INSIGHTS");

    public static readonly ReportType1 PricingInsightsMx = new("PRICING_INSIGHTS_MX");

    public static readonly ReportType1 PricingInsightsCa = new("PRICING_INSIGHTS_CA");

    public static readonly ReportType1 WalmartFundedIncentives = new("WALMART_FUNDED_INCENTIVES");

    public static readonly ReportType1 IncentivesEnrollment = new("INCENTIVES_ENROLLMENT");

    public static readonly ReportType1 Incentives = new("INCENTIVES");

    public static readonly ReportType1 WalmartFundedIncentivesCa = new("WALMART_FUNDED_INCENTIVES_CA");

    public static readonly ReportType1 IncentivesEnrollmentCa = new("INCENTIVES_ENROLLMENT_CA");

    public static readonly ReportType1 IncentivesCa = new("INCENTIVES_CA");

    public static readonly ReportType1 FitmentAcesCoverage = new("FITMENT_ACES_COVERAGE");

    public static readonly ReportType1 FitmentMissingAttr = new("FITMENT_MISSING_ATTR");

    public static readonly ReportType1 Order = new("ORDER");

    public static readonly ReportType1 Otd = new("OTD");

    public static readonly ReportType1 B2BItem = new("B2B_ITEM");

    public static readonly ReportType1 OrderMx = new("ORDER_MX");

    public static readonly ReportType1 InventoryDsv = new("INVENTORY_DSV");

    public static readonly ReportType1 OrderIntl = new("ORDER_INTL");

    public static readonly ReportType1 ItemCa = new("ITEM_CA");

    public static readonly ReportType1 InventoryCa = new("INVENTORY_CA");

    public static readonly ReportType1 InventoryPreorder = new("INVENTORY_PREORDER");

    public static readonly ReportType1 ItemMx = new("ITEM_MX");

    public static readonly ReportType1 InventoryMx = new("INVENTORY_MX");

    public static readonly ReportType1 SponDealOrderMx = new("SPON_DEAL_ORDER_MX");

    public static readonly ReportType1 AssortmentRecommendations = new("ASSORTMENT_RECOMMENDATIONS");

    public static readonly ReportType1 AssortmentRecommendationsSc = new("ASSORTMENT_RECOMMENDATIONS_SC");

    public static readonly ReportType1 AssortmentExplorerSc = new("ASSORTMENT_EXPLORER_SC");

    public static readonly ReportType1 AssortmentShortlistingSc = new("ASSORTMENT_SHORTLISTING_SC");

    public static readonly ReportType1 AssortmentAcquisitionSc = new("ASSORTMENT_ACQUISITION_SC");

    public static readonly ReportType1 AssortmentOptimizationSc = new("ASSORTMENT_OPTIMIZATION_SC");

    public static readonly ReportType1 ProductContentData = new("PRODUCT_CONTENT_DATA");

    public static readonly ReportType1 ItemConfigurationData = new("ITEM_CONFIGURATION_DATA");

    public static readonly ReportType1 Discount = new("DISCOUNT");

    public static readonly ReportType1 DiscountCa = new("DISCOUNT_CA");

    public static readonly ReportType1 DiscountMx = new("DISCOUNT_MX");

    public static readonly ReportType1 Lagtime = new("LAGTIME");

    public static readonly ReportType1 LagtimeCa = new("LAGTIME_CA");

    public static readonly ReportType1 LagtimeMx = new("LAGTIME_MX");

    public static readonly ReportType1 LagtimeCl = new("LAGTIME_CL");

    public static readonly ReportType1 VirtualPack = new("VIRTUAL_PACK");

    public static readonly ReportType1 ItemSales = new("ITEM_SALES");

    public static readonly ReportType1 DsvOrders = new("DSV_ORDERS");

    public static readonly ReportType1 SearchInsightsPerfReport = new("SEARCH_INSIGHTS_PERF_REPORT");

    public static readonly ReportType1 ItemCl = new("ITEM_CL");

    public static readonly ReportType1 InventoryCl = new("INVENTORY_CL");

    public static readonly ReportType1 PaidNinety = new("PAID_NINETY");

    public static readonly ReportType1 ItemGroups = new("ITEM_GROUPS");

    public static readonly ReportType1 DraftItemGroups = new("DRAFT_ITEM_GROUPS");

    public static readonly ReportType1 VendorManagedPricing = new("VENDOR_MANAGED_PRICING");

    public static readonly ReportType1 Invoices = new("INVOICES");

    public static readonly ReportType1 SwwSellerReconciliation = new("SWW_SELLER_RECONCILIATION");

    public static readonly ReportType1 SchedulingDeliveryAndServices = new("SCHEDULING_DELIVERY_AND_SERVICES");

    public static readonly ReportType1 SearchInsightsSqrReport = new("SEARCH_INSIGHTS_SQR_REPORT");

    public static readonly ReportType1 WalmartFundedIncentivesMx = new("WALMART_FUNDED_INCENTIVES_MX");

    public static readonly ReportType1 IncentivesEnrollmentMx = new("INCENTIVES_ENROLLMENT_MX");

    public static readonly ReportType1 IncentivesMx = new("INCENTIVES_MX");

    public static readonly ReportType1 ApiTrafficReport = new("API_TRAFFIC_REPORT");

    public static readonly ReportType1 SwwEodScanForms = new("SWW_EOD_SCAN_FORMS");

    public static readonly ReportType1 SwwBulkPrintLabels = new("SWW_BULK_PRINT_LABELS");

    public static readonly ReportType1 DeleteSku = new("DELETE_SKU");

    public static readonly ReportType1 Promogroup = new("PROMOGROUP");

    public static readonly ReportType1 InventoryRecommendations = new("INVENTORY_RECOMMENDATIONS");

    public static readonly ReportType1 InventoryRecon = new("INVENTORY_RECON");

    public static readonly ReportType1 Settlement = new("SETTLEMENT");

    public static readonly ReportType1 WalmartFundedEs = new("WALMART_FUNDED_ES");

    public static readonly ReportType1 SemPerformance = new("SEM_PERFORMANCE");

    public static readonly ReportType1 SemSearchTerms = new("SEM_SEARCH_TERMS");

    public static readonly ReportType1 WfsOrders = new("WFS_ORDERS");

    public static readonly ReportType1 WfsInventoryLog = new("WFS_INVENTORY_LOG");

    public static readonly ReportType1 WfsCustomerReturns = new("WFS_CUSTOMER_RETURNS");

    public static readonly ReportType1 CustomItemInventory = new("CUSTOM_ITEM_INVENTORY");

    public static readonly ReportType1 ListingQuality = new("LISTING_QUALITY");

    public static ReportType1 FromValue(string value) => FromValueCore(value);
}
