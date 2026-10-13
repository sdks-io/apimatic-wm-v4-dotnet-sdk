using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Reason for cancelling or rescheduling a self-ship appointment.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonReasonComment>))]
public sealed record CommonReasonComment : OpenStringEnum<CommonReasonComment>
{
    private CommonReasonComment(string value) : base(value)
    {
    }

    public static readonly CommonReasonComment AppointmentRequestedByMistake = new("APPOINTMENT_REQUESTED_BY_MISTAKE");

    public static readonly CommonReasonComment VehicleDelay = new("VEHICLE_DELAY");

    public static readonly CommonReasonComment SlotNotSuitable = new("SLOT_NOT_SUITABLE");

    public static readonly CommonReasonComment OutsideCarrierBusinessHours = new("OUTSIDE_CARRIER_BUSINESS_HOURS");

    public static readonly CommonReasonComment UnfavourableExternalConditions = new("UNFAVOURABLE_EXTERNAL_CONDITIONS");

    public static readonly CommonReasonComment ProcurementDelay = new("PROCUREMENT_DELAY");

    public static readonly CommonReasonComment ShippingPlanChanged = new("SHIPPING_PLAN_CHANGED");

    public static readonly CommonReasonComment IncreasedQuantity = new("INCREASED_QUANTITY");

    public static readonly CommonReasonComment Other = new("OTHER");

    public TResult Match<TResult>(Func<TResult> onAppointmentRequestedByMistake,
        Func<TResult> onVehicleDelay,
        Func<TResult> onSlotNotSuitable,
        Func<TResult> onOutsideCarrierBusinessHours,
        Func<TResult> onUnfavourableExternalConditions,
        Func<TResult> onProcurementDelay,
        Func<TResult> onShippingPlanChanged,
        Func<TResult> onIncreasedQuantity,
        Func<TResult> onOther,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == AppointmentRequestedByMistake => onAppointmentRequestedByMistake(),
            _ when this == VehicleDelay => onVehicleDelay(),
            _ when this == SlotNotSuitable => onSlotNotSuitable(),
            _ when this == OutsideCarrierBusinessHours => onOutsideCarrierBusinessHours(),
            _ when this == UnfavourableExternalConditions => onUnfavourableExternalConditions(),
            _ when this == ProcurementDelay => onProcurementDelay(),
            _ when this == ShippingPlanChanged => onShippingPlanChanged(),
            _ when this == IncreasedQuantity => onIncreasedQuantity(),
            _ when this == Other => onOther(),
            _ => otherwise(Value)
        };

    public void Match(Action onAppointmentRequestedByMistake,
        Action onVehicleDelay,
        Action onSlotNotSuitable,
        Action onOutsideCarrierBusinessHours,
        Action onUnfavourableExternalConditions,
        Action onProcurementDelay,
        Action onShippingPlanChanged,
        Action onIncreasedQuantity,
        Action onOther,
        Action<string> otherwise)
    {
        if (this == AppointmentRequestedByMistake) onAppointmentRequestedByMistake();
        else if (this == VehicleDelay) onVehicleDelay();
        else if (this == SlotNotSuitable) onSlotNotSuitable();
        else if (this == OutsideCarrierBusinessHours) onOutsideCarrierBusinessHours();
        else if (this == UnfavourableExternalConditions) onUnfavourableExternalConditions();
        else if (this == ProcurementDelay) onProcurementDelay();
        else if (this == ShippingPlanChanged) onShippingPlanChanged();
        else if (this == IncreasedQuantity) onIncreasedQuantity();
        else if (this == Other) onOther();
        else otherwise(Value);
    }
}
