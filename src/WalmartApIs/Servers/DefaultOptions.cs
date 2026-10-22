using WalmartApIs.Core.Models;

namespace WalmartApIs.Servers;

public class DefaultOptions
{
    public ProductionOptions Production { get; set; } = new();
    public SandboxOptions Sandbox { get; set; } = new();

    internal UrlTemplate Resolve(ServerEnvironment environment, string path) =>
        environment.Match(
            () => new UrlTemplate(Production.BaseUrl, path, []),
            () => new UrlTemplate(Sandbox.BaseUrl, path, []));

    public class ProductionOptions
    {
        public string BaseUrl { get; set; } = "https://marketplace.walmartapis.com";
    }

    public class SandboxOptions
    {
        public string BaseUrl { get; set; } = "https://sandbox.walmartapis.com";
    }
}
