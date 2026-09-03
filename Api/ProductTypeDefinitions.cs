using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WalmartApIs.Core;
using WalmartApIs.Core.Exceptions;
using WalmartApIs.Core.Models;
using WalmartApIs.Core.Request;
using WalmartApIs.Core.Response;
using WalmartApIs.Errors;
using WalmartApIs.Models;

namespace WalmartApIs.Api;

public sealed class ProductTypeDefinitions
{
    private readonly RawClient _rawClient;
    private readonly Server _server;
    private readonly AuthSchemes _auth;

    internal ProductTypeDefinitions(RawClient rawClient, Server server, AuthSchemes auth)
    {
        _rawClient = rawClient;
        _server = server;
        _auth = auth;
    }

    /// <summary>
    /// Returns the schema for a specific product type
    /// </summary>
    /// <param name="productType"></param>
    /// <param name="sellerId"></param>
    /// <param name="locale"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductTypeDefinition"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="GetDefinitionsProductTypeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Placeholder — not yet implemented.</b>
    /// </remarks>
    public Task<ProductTypeDefinition> GetDefinitionsProductType(string productType,
        string? sellerId,
        string? locale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/definitions/v4/productTypes/{productType}"),
            [new TemplateParam("productType", productType)],
            [new Param("sellerId", sellerId), new Param("locale", locale)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ProductTypeDefinition>(),
            GetDefinitionsProductTypeErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);

    /// <summary>
    /// Returns a list of product type definitions
    /// </summary>
    /// <param name="keywords"></param>
    /// <param name="itemName"></param>
    /// <param name="locale"></param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductTypeList"/> instance.</returns>
    /// <exception cref="SdkException{TResult}"> of <see cref="SearchDefinitionsProductTypesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Placeholder — not yet implemented.</b>
    /// </remarks>
    public Task<ProductTypeList> SearchDefinitionsProductTypes(string? keywords,
        string? itemName,
        string? locale = "en_US",
        RequestOptions? requestOptions = null,
        CancellationToken ct = default) =>
        _rawClient.Execute(_server.Default1("/definitions/v4/productTypes"),
            [],
            [new Param("keywords", keywords), new Param("itemName", itemName), new Param("locale", locale)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ProductTypeList>(),
            SearchDefinitionsProductTypesErrorResponse.Instance,
            [_auth.WalletAuth],
            requestOptions,
            ct);
}
