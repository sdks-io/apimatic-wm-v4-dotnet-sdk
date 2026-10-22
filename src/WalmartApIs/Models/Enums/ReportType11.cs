using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Specifies the type of report to be generated. Example: ITEM for Item Report.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<ReportType11>))]
public sealed record ReportType11 : OpenStringEnum<ReportType11>
{
    private ReportType11(string value) : base(value)
    {
    }

    public static readonly ReportType11 Item = new("ITEM");

    public static readonly ReportType11 Inventory = new("INVENTORY");

    public static readonly ReportType11 Cancellation = new("CANCELLATION");

    public static readonly ReportType11 DeliveryDefect = new("DELIVERY_DEFECT");

    public static readonly ReportType11 ItemPerformance = new("ITEM_PERFORMANCE");

    public static readonly ReportType11 Promo = new("PROMO");

    public static readonly ReportType11 ReturnOverrides = new("RETURN_OVERRIDES");

    public static readonly ReportType11 Cpa = new("CPA");

    public static readonly ReportType11 ShippingConfiguration = new("SHIPPING_CONFIGURATION");

    public static readonly ReportType11 ShippingProgram = new("SHIPPING_PROGRAM");

    public static readonly ReportType11 Buybox = new("BUYBOX");

    public static readonly ReportType11 AssortmentRecommendations = new("ASSORTMENT_RECOMMENDATIONS");

    public static readonly ReportType11 Lagtime = new("LAGTIME");

    public static readonly ReportType11 InventoryRecommendations = new("INVENTORY_RECOMMENDATIONS");

    public static readonly ReportType11 SemPerformance = new("SEM_PERFORMANCE");

    public TResult Match<TResult>(Func<TResult> onItem,
        Func<TResult> onInventory,
        Func<TResult> onCancellation,
        Func<TResult> onDeliveryDefect,
        Func<TResult> onItemPerformance,
        Func<TResult> onPromo,
        Func<TResult> onReturnOverrides,
        Func<TResult> onCpa,
        Func<TResult> onShippingConfiguration,
        Func<TResult> onShippingProgram,
        Func<TResult> onBuybox,
        Func<TResult> onAssortmentRecommendations,
        Func<TResult> onLagtime,
        Func<TResult> onInventoryRecommendations,
        Func<TResult> onSemPerformance,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Item => onItem(),
            _ when this == Inventory => onInventory(),
            _ when this == Cancellation => onCancellation(),
            _ when this == DeliveryDefect => onDeliveryDefect(),
            _ when this == ItemPerformance => onItemPerformance(),
            _ when this == Promo => onPromo(),
            _ when this == ReturnOverrides => onReturnOverrides(),
            _ when this == Cpa => onCpa(),
            _ when this == ShippingConfiguration => onShippingConfiguration(),
            _ when this == ShippingProgram => onShippingProgram(),
            _ when this == Buybox => onBuybox(),
            _ when this == AssortmentRecommendations => onAssortmentRecommendations(),
            _ when this == Lagtime => onLagtime(),
            _ when this == InventoryRecommendations => onInventoryRecommendations(),
            _ when this == SemPerformance => onSemPerformance(),
            _ => otherwise(Value)
        };

    public void Match(Action onItem,
        Action onInventory,
        Action onCancellation,
        Action onDeliveryDefect,
        Action onItemPerformance,
        Action onPromo,
        Action onReturnOverrides,
        Action onCpa,
        Action onShippingConfiguration,
        Action onShippingProgram,
        Action onBuybox,
        Action onAssortmentRecommendations,
        Action onLagtime,
        Action onInventoryRecommendations,
        Action onSemPerformance,
        Action<string> otherwise)
    {
        if (this == Item) onItem();
        else if (this == Inventory) onInventory();
        else if (this == Cancellation) onCancellation();
        else if (this == DeliveryDefect) onDeliveryDefect();
        else if (this == ItemPerformance) onItemPerformance();
        else if (this == Promo) onPromo();
        else if (this == ReturnOverrides) onReturnOverrides();
        else if (this == Cpa) onCpa();
        else if (this == ShippingConfiguration) onShippingConfiguration();
        else if (this == ShippingProgram) onShippingProgram();
        else if (this == Buybox) onBuybox();
        else if (this == AssortmentRecommendations) onAssortmentRecommendations();
        else if (this == Lagtime) onLagtime();
        else if (this == InventoryRecommendations) onInventoryRecommendations();
        else if (this == SemPerformance) onSemPerformance();
        else otherwise(Value);
    }
}
