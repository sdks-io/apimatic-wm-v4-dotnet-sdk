using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Servers;

[JsonConverter(typeof(StringEnumConverter<ServerEnvironment>))]
public record ServerEnvironment : StringEnum<ServerEnvironment>
{
    /// <summary>
    /// Production
    /// </summary>
    public static readonly ServerEnvironment Production = new("production");
    /// <summary>
    /// Sandbox
    /// </summary>
    public static readonly ServerEnvironment Environment2 = new("environment2");
    /// <summary>
    /// mock
    /// </summary>
    public static readonly ServerEnvironment Environment3 = new("environment3");

    private ServerEnvironment(string value) : base(value)
    {
    }

    internal T Match<T>(Func<T> onProduction, Func<T> onEnvironment2, Func<T> onEnvironment3) =>
        this switch
        {
            _ when this == Production => onProduction(),
            _ when this == Environment2 => onEnvironment2(),
            _ when this == Environment3 => onEnvironment3(),
            _ => throw new ArgumentOutOfRangeException(nameof(ServerEnvironment),
                this,
                $"Unknown {nameof(ServerEnvironment)} value.")
        };

    public static ServerEnvironment Default() => Production;
}
