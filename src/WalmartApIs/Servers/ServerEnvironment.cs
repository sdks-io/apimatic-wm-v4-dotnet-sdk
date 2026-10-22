using System;
using System.Text.Json.Serialization;
using WalmartApIs.Core.Enum;

namespace WalmartApIs.Servers;

[JsonConverter(typeof(StringEnumConverter<ServerEnvironment>))]
public sealed record ServerEnvironment : ClosedStringEnum<ServerEnvironment>
{
    private ServerEnvironment(string value) : base(value)
    {
    }

    /// <summary>
    /// Production URL, Specifies the production URL., Specifies the production URL., Production URL, Specifies the production URL., Specifies the production URL., Refers to the URL used for accessing the production server., Specifies the production URL., Refers to the URL used for accessing the production server., Production URL, Production URL, Production server for all APIs., Production URL, Production URL, Production URL, Base URL for production requests., Production URL, Production URL, Production URL, Refers to the URL used for accessing the production server.
    /// </summary>
    public static readonly ServerEnvironment Production = new("production");

    /// <summary>
    /// Sandbox URL, Specifies the sandbox URL., Specifies the sandbox URL., Sandbox URL, Specifies the sandbox URL., Specifies the sandbox URL., Refers to the URL used for accessing the sandbox server., Specifies the sandbox URL., Refers to the URL used for accessing the sandbox server., Sandbox URL, Sandbox URL, Sandbox URL, Sandbox URL, Sandbox URL, Base URL for sandbox requests., Sandbox URL, Sandbox URL, Sandbox URL, Refers to the URL used for accessing the sandbox server.
    /// </summary>
    public static readonly ServerEnvironment Environment2 = new("environment2");

    public static ServerEnvironment Default() => Production;

    internal TResult Match<TResult>(Func<TResult> onProduction, Func<TResult> onEnvironment2) =>
        this switch
        {
            _ when this == Production => onProduction(),
            _ when this == Environment2 => onEnvironment2(),
            _ => throw new InvalidOperationException($"{nameof(ServerEnvironment)} holds no known value.")
        };
}
