using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Models.Enums;

/// <summary>
/// | Market | Translation |
/// | --- | ----------- |
/// | CA  | ["Create", "Delete","Replace All"]|
/// | MX &amp; CL | ["Crear", "Eliminar","Reemplazar todo"]|
/// <para>
/// &lt;br&gt;&lt;b style='color:green;'&gt;Market availability: CA | MX | CL
/// </para>
/// </summary>
[JsonConverter(typeof(StringEnumConverter<PromotionSettingAction>))]
public sealed record PromotionSettingAction : OpenStringEnum<PromotionSettingAction>
{
    private PromotionSettingAction(string value) : base(value)
    {
    }

    public static readonly PromotionSettingAction Create = new("Create");

    public static readonly PromotionSettingAction Delete = new("Delete");

    public static readonly PromotionSettingAction ReplaceAll = new("Replace All");

    public static readonly PromotionSettingAction Crear = new("Crear");

    public static readonly PromotionSettingAction Eliminar = new("Eliminar");

    public static readonly PromotionSettingAction ReemplazarTodo = new("Reemplazar todo");

    public TResult Match<TResult>(Func<TResult> onCreate,
        Func<TResult> onDelete,
        Func<TResult> onReplaceAll,
        Func<TResult> onCrear,
        Func<TResult> onEliminar,
        Func<TResult> onReemplazarTodo,
        Func<string, TResult> otherwise) =>
        this switch
        {
            _ when this == Create => onCreate(),
            _ when this == Delete => onDelete(),
            _ when this == ReplaceAll => onReplaceAll(),
            _ when this == Crear => onCrear(),
            _ when this == Eliminar => onEliminar(),
            _ when this == ReemplazarTodo => onReemplazarTodo(),
            _ => otherwise(Value)
        };

    public void Match(Action onCreate,
        Action onDelete,
        Action onReplaceAll,
        Action onCrear,
        Action onEliminar,
        Action onReemplazarTodo,
        Action<string> otherwise)
    {
        if (this == Create) onCreate();
        else if (this == Delete) onDelete();
        else if (this == ReplaceAll) onReplaceAll();
        else if (this == Crear) onCrear();
        else if (this == Eliminar) onEliminar();
        else if (this == ReemplazarTodo) onReemplazarTodo();
        else otherwise(Value);
    }
}
