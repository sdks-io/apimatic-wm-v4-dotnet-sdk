using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// Reason for cancelling or rescheduling a self-ship appointment.
/// </summary>
[JsonConverter(typeof(StringEnumConverter<CommonReasonComment>))]
public sealed record CommonReasonComment : StringEnum<CommonReasonComment>
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

    public static CommonReasonComment FromValue(string value) => FromValueCore(value);
}
