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
using WalmartApIs.Requests.ProductTypeDefinitions;

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
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductTypeDefinition"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="GetDefinitionsProductTypeError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Placeholder — not yet implemented.</b>
    /// </remarks>
    public Task<ProductTypeDefinition> GetDefinitionsProductType(GetDefinitionsProductTypeRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/definitions/v4/productTypes/{productType}"),
            [new TemplateParam("productType", request.ProductType)],
            [new Param("sellerId", request.SellerId), new Param("locale", request.Locale)],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ProductTypeDefinition>(),
            GetDefinitionsProductTypeError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);

    /// <summary>
    /// Returns a list of product type definitions
    /// </summary>
    /// <param name="request">The operation's inputs</param>
    /// <param name="requestOptions">Per-request options, such as an overriding log level for this call</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="Task{TResult}"/> of <see cref="ProductTypeList"/> instance.</returns>
    /// <exception cref="ApiException{TError}"> of <see cref="SearchDefinitionsProductTypesError"/> when the server returns an error response.</exception>
    /// <remarks>
    /// <b>Placeholder — not yet implemented.</b>
    /// </remarks>
    public Task<ProductTypeList> SearchDefinitionsProductTypes(SearchDefinitionsProductTypesRequest request,
        RequestOptions? requestOptions = null,
        CancellationToken cancellationToken = default) =>
        _rawClient.Execute(
            _server.Default1("/definitions/v4/productTypes"),
            [],
            [
                new Param("keywords", request.Keywords),
                new Param("itemName", request.ItemName),
                new Param("locale", request.Locale),
            ],
            [],
            HttpMethod.Get,
            EmptyBody.Instance,
            JsonResponse.Create<ProductTypeList>(),
            SearchDefinitionsProductTypesError.Response,
            [_auth.WalletAuth],
            requestOptions,
            cancellationToken);
}
